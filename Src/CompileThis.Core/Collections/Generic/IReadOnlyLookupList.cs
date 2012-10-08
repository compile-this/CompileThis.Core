namespace CompileThis.Collections.Generic
{
    using System.Collections.Generic;

    public interface IReadOnlyLookupList<in TKey, out TValue> : IReadOnlyCollection<TValue>, ILookup<TKey, TValue>
    { }
}