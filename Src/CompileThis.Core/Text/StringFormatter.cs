namespace CompileThis.Text
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public static class StringFormatter
    {
        private static readonly Regex TokenExpression = new Regex(@"\$\{(?<token>[a-zA-Z0-9-]+)\}");

        public static string Format(string text, IStringFormatterValueProvider valueProvider)
        {
            Guard.NullParameter(text, () => text);
            Guard.NullParameter(valueProvider, () => valueProvider);

            return TokenExpression.Replace(text, m => valueProvider.ProvideValue(m.Groups["token"].Value) ?? "");
        }

        public static string Format(string text, IDictionary<string, string> dictionary)
        {
            Guard.NullParameter(text, () => text);
            Guard.NullParameter(dictionary, () => dictionary);

            return Format(text, new DictionaryValueProvider(dictionary));
        }
    }
}
