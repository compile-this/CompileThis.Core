namespace CompileThis.Collections.Generic
{
    using FluentAssertions;
    using Xunit;

    public class LookupListFacts
    {
        [Fact]
        public void LookupList_key_indexer_returns_value()
        {
            var list = new LookupList<string, Item>(x => x.Name);
            var item = new Item {Name = "key", Value = 12};
            list.Add(item);

            list["key"].Should().Be(item);
        }

        [Fact]
        public void LookupList_index_indexer_returns_value()
        {
            var list = new LookupList<string, Item>(x => x.Name);
            var item = new Item { Name = "key", Value = 12 };
            list.Add(item);

            list[0].Should().Be(item);
        }

        class Item
        {
            public string Name { get; set; }
            public int Value { get; set; }
        }
    }
}
