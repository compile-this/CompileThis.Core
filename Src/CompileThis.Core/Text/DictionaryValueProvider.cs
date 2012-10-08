namespace CompileThis.Text
{
    using System.Collections.Generic;

    internal class DictionaryValueProvider : IStringFormatterValueProvider
    {
        private readonly IDictionary<string, string> _dictionary;

        public DictionaryValueProvider(IDictionary<string, string> dictionary)
        {
            Guard.NullParameter(dictionary, () => dictionary);

            _dictionary = dictionary;
        }

        public string ProvideValue(string token)
        {
            Guard.NullParameter(token, () => token);

            string value;
            return _dictionary.TryGetValue(token, out value) ? value : null;
        }
    }
}