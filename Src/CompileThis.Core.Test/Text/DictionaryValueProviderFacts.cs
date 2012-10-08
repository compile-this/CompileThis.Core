namespace CompileThis.Text
{
    using System.Collections.Generic;

    using FluentAssertions;

    using Xunit;

    public class DictionaryValueProviderFacts
    {
        [Fact]
        public void DictionaryValueProvider_defined_token_returns_value()
        {
            var dictionary = new Dictionary<string, string>
                {
                    {"key", "value"}
                };

            var valueProvider = new DictionaryValueProvider(dictionary);

            var value = valueProvider.ProvideValue("key");

            value.Should().Be("value");
        }

        [Fact]
        public void DictionaryValueProvider_undefined_token_returns_null()
        {
            var dictionary = new Dictionary<string, string>
                {
                    {"key", "value"}
                };

            var valueProvider = new DictionaryValueProvider(dictionary);

            var value = valueProvider.ProvideValue("key2");

            value.Should().BeNull();
        }
    }
}
