namespace CompileThis.Collections.Generic
{
    public interface ILookup<in TKey, out TValue>
    {
        TValue this[TKey key] { get; }
        TValue this[int index] { get; }
        bool Contains(TKey key);
        TValue GetValueOrDefault(TKey key);
    }
}
