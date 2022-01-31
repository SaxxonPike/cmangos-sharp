using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace Mangos.Core.Config;

public sealed class MangosConfiguration : IConfigurationRoot
{
    private readonly string _fileName;
    private readonly IConfigurationProvider _provider;
    private ChangeToken _changeToken;

    public MangosConfiguration(string fileName)
    {
        _fileName = fileName;
        Reload();
        _provider = new Provider(this);
    }

    private Dictionary<string, IConfigurationSection> Sections { get; } = new();

    public IConfigurationSection GetSection(string key) =>
        Sections.TryGetValue(key.ToLowerInvariant(), out var section)
            ? section
            : EmptySection.Instance;

    public IEnumerable<IConfigurationSection> GetChildren() => Sections.Values;

    public IChangeToken GetReloadToken() => _changeToken;

    public string this[string key]
    {
        get => TryGet(key, out var value) ? value : default;
        set => Set(key, value);
    }

    public void Reload()
    {
        using var stream = File.Open(_fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
        using var reader = new StreamReader(stream);
        var section = new Dictionary<string, string>();
        var sections = new Dictionary<string, Dictionary<string, string>> { { string.Empty, section } };

        while (true)
        {
            var line = reader.ReadLine()?.Trim();
            if (line == default)
                break;

            if (line == string.Empty || line.StartsWith('#'))
                continue;

            if (line.StartsWith('['))
            {
                if (!line.EndsWith(']'))
                    continue;
                var sectionName = line.Substring(1, line.Length - 2).ToLowerInvariant();
                if (!sections.ContainsKey(sectionName))
                    sections[sectionName] = new Dictionary<string, string>();
                section = sections[sectionName];
            }
            else if (line.Contains('='))
            {
                var key = line[..line.IndexOf('=')].ToLowerInvariant();
                var value = line[(key.Length + 1)..].Trim();
                if (value.StartsWith('\"') && value.EndsWith('\"'))
                    value = value.Substring(1, value.Length - 2);
                section[key.Trim()] = value;
            }
        }

        Sections.Clear();
        foreach (var (key, values) in sections)
            Sections.Add(key, new Section(this, values, key));

        _changeToken?.OnChange();
        _changeToken = new ChangeToken();
    }

    public IEnumerable<IConfigurationProvider> Providers
    {
        get
        {
            yield return _provider;
        }
    }

    private bool TryGet(string key, out string value)
    {
        if (key == default)
        {
            value = default;
            return false;
        }

        var period = key.IndexOf('.');
        if (period >= 0)
        {
            var sectionName = key[..key.IndexOf('.')].ToLowerInvariant().Trim();
            if (Sections.TryGetValue(sectionName, out var section))
                return ((Section)section).TryGet(key[(period + 1)..], out value);
        }
        else
        {
            if (Sections.TryGetValue(string.Empty, out var section))
                return ((Section)section).TryGet(key, out value);
        }
        
        value = default;
        return false;
    }

    private void Set(string key, string value)
    {
        if (key == default)
            return;

        var period = key.IndexOf('.');
        if (period >= 0)
        {
            var sectionName = key[..key.IndexOf('.')].ToLowerInvariant().Trim();
            if (Sections.TryGetValue(sectionName, out var section))
                ((Section)section).Set(key[(period + 1)..], value);
        }
        else
        {
            if (Sections.TryGetValue(string.Empty, out var section))
                ((Section)section).Set(key, value);
        }
    }
    
    private sealed class Provider : IConfigurationProvider
    {
        private readonly MangosConfiguration _configuration;

        public Provider(MangosConfiguration configuration) => 
            _configuration = configuration;

        public bool TryGet(string key, out string value) => 
            _configuration.TryGet(key, out value);

        public void Set(string key, string value) => 
            _configuration.Set(key, value);

        public IChangeToken GetReloadToken() => 
            throw new NotImplementedException();

        public void Load() => 
            _configuration.Reload();

        public IEnumerable<string> GetChildKeys(IEnumerable<string> earlierKeys, string parentPath) => 
            throw new NotImplementedException();
    }

    private sealed class EmptySection : IConfigurationSection
    {
        public static readonly EmptySection Instance = new();

        private EmptySection()
        {
        }

        public IConfigurationSection GetSection(string key) => 
            Instance;

        public IEnumerable<IConfigurationSection> GetChildren() => 
            Enumerable.Empty<IConfigurationSection>();

        public IChangeToken GetReloadToken() => 
            throw new NotImplementedException();

        public string this[string key]
        {
            get => default;
            set { }
        }

        public string Key => 
            throw new NotImplementedException();
        
        public string Path => 
            throw new NotImplementedException();

        public string Value
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
    }
    
    private sealed class Section : IConfigurationSection
    {
        private readonly MangosConfiguration _root;
        private readonly Dictionary<string, string> _values;

        public Section(MangosConfiguration root, Dictionary<string, string> values, string key)
        {
            _root = root;
            _values = values;
            Key = key;
        }

        public IConfigurationSection GetSection(string key) => this;

        public IEnumerable<IConfigurationSection> GetChildren() => 
            Enumerable.Empty<IConfigurationSection>();

        public IChangeToken GetReloadToken() => 
            _root.GetReloadToken();

        public string this[string key]
        {
            get => TryGet(key, out var value) ? value : default;
            set => Set(key, value);
        }

        public string Key { get; }

        public string Path => Key;

        public string Value
        {
            get => default;
            set { }
        }

        public bool TryGet(string key, out string value) => 
            _values.TryGetValue(key.ToLowerInvariant(), out value);

        public void Set(string key, string value) => 
            _values[key.ToLowerInvariant()] = value;
    }
    
    private sealed class ChangeToken : IChangeToken
    {
        private readonly List<(Action<object> Callback, object State)> _callbacks;

        public ChangeToken()
        {
            _callbacks = new List<(Action<object> Callback, object State)>();
        }

        public IDisposable RegisterChangeCallback(Action<object> callback, object state)
        {
            if (HasChanged)
                return default;
            _callbacks.Add((callback, state));
            return new ChangeTokenDisposer(() => _callbacks.Remove((callback, state)));
        }
        
        public bool HasChanged { get; private set; }

        public bool ActiveChangeCallbacks => true;

        public void OnChange()
        {
            if (HasChanged)
                return;

            HasChanged = true;
            foreach (var cb in _callbacks)
                cb.Callback(cb.State);
        }

        private sealed class ChangeTokenDisposer : IDisposable
        {
            private readonly Action _onDispose;
            private bool _disposed;

            public ChangeTokenDisposer(Action onDispose)
            {
                _onDispose = onDispose;
            }

            public void Dispose()
            {
                if (_disposed)
                    return;
                _disposed = true;
                _onDispose();
            }
        }
    }
}



