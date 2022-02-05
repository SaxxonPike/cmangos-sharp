using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MangosSharp.Server.Core.Views;

public sealed class MemoryLongField : IEnumerable<long>
{
    private readonly IViewBase _view;
    private readonly int _index;
    private readonly int _length;
    private readonly int _size;

    public MemoryLongField(IViewBase view, int index, int length, int size)
    {
        _view = view;
        _index = index;
        _length = length;
        _size = size;
    }

    public IEnumerator<long> GetEnumerator() => Enumerable.Range(0, _length).Select(i => this[i]).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public long this[int index]
    {
        get => _view.RawFields.Span[_index + _size * index] | (long)_view.RawFields.Span[_index + _size * index + 1] << 32;
        set
        {
            _view.RawFields.Span[_index + _size * index] = unchecked((int)(value));
            _view.RawFields.Span[_index + _size * index + 1] = unchecked((int)(value >> 32));
        }
    }
}