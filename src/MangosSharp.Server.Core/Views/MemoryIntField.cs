using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MangosSharp.Server.Core.Views;

public sealed class MemoryIntField : IEnumerable<int>
{
    private readonly IViewBase _view;
    private readonly int _index;
    private readonly int _length;
    private readonly int _size;

    public MemoryIntField(IViewBase view, int index, int length, int size)
    {
        _view = view;
        _index = index;
        _length = length;
        _size = size;
    }

    public IEnumerator<int> GetEnumerator() => Enumerable.Range(0, _length).Select(i => this[i]).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public int this[int index]
    {
        get => _view.RawFields.Span[_index + _size * index];
        set => _view.RawFields.Span[_index + _size * index] = value;
    }
}