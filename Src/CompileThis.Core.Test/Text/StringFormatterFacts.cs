namespace CompileThis.Text
{
    using FluentAssertions;

    using Moq;

    using Xunit;

    public class StringFormatterFacts
    {
        [Fact]
        public void Text_without_tokens_is_unchanged()
        {
            var valueProviderMock = new Mock<IStringFormatterValueProvider>();
            valueProviderMock.Setup(x => x.ProvideValue(It.IsAny<string>())).Returns("VALUE");

            const string expected = "TEST STRING";
            var actual = StringFormatter.Format(expected, valueProviderMock.Object);

            actual.Should().Be(expected);
        }

        [Fact]
        public void Tokens_in_text_are_replaced()
        {
            var valueProviderMock = new Mock<IStringFormatterValueProvider>();
            valueProviderMock.Setup(x => x.ProvideValue(It.IsAny<string>())).Returns("VALUE");

            var actual = StringFormatter.Format("TEST ${token} STRING", valueProviderMock.Object);

            actual.Should().Be("TEST VALUE STRING");
        }
    }
}
