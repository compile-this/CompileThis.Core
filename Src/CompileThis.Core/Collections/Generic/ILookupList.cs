namespace CompileThis.Collections.Generic
{
    using System.Collections.Generic;

    public interface ILookupList<in TKey, TValue> : ICollection<TValue>, ILookup<TKey, TValue>
        where TValue : class
    {
        bool Remove(TKey key);
    }
}