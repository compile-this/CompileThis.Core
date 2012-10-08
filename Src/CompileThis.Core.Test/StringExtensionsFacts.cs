namespace CompileThis
{
    using System;
    using FluentAssertions;

    using Xunit;

    public class StringExtensionsFacts
    {
        [Fact]
        public void FormatWith_applies_format_to_string()
        {
            var actual = "test {0} test".FormatWith("value");

            actual.Should().Be("test value test");
        }

        [Fact]
        public void FormatWith_throws_on_null_string()
        {
            string source = null;

            Action action = () => source.FormatWith("value");
            action.ShouldThrow<ArgumentNullException>();
        }
    }
}
