namespace CompileThis
{
    using System;

    using FluentAssertions;

    using Xunit;

    public class GuardFacts
    {
        [Fact]
        public void NullParameter_should_not_throw_with_value()
        {
            Action action = () => StringTest("Value");
            
            action.ShouldNotThrow();
        }

        [Fact]
        public void NullParameter_with_expression_should_not_throw_with_value()
        {
            Action action = () => ExpressionTest("Value");

            action.ShouldNotThrow();
        }

        [Fact]
        public void NullParameter_should_throw_on_null()
        {
            Action action = () => StringTest(null);

            action.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("type");
        }

        [Fact]
        public void NullParameter_with_expression_should_throw_on_null()
        {
            Action action = () => ExpressionTest(null);

            action.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("type");
        }

        [Fact]
        public void NullParameter_should_throw_with_message_on_null()
        {
            Action action = () => StringMessageTest(null);

            action.ShouldThrow<ArgumentNullException>().WithMessage("A message", ComparisonMode.StartWith).And.ParamName.Should().Be("type");
        }

        [Fact]
        public void NullParameter_with_expression_should_throw_with_message_on_null()
        {
            Action action = () => ExpressionMessageTest(null);

            action.ShouldThrow<ArgumentNullException>().WithMessage("A message", ComparisonMode.StartWith).And.ParamName.Should().Be("type");
        }

        private static void StringTest(string type)
        {
            Guard.NullParameter(type, "type");
        }

        private static void StringMessageTest(string type)
        {
            Guard.NullParameter(type, "type", "A message");
        }

        private static void ExpressionTest(string type)
        {
            Guard.NullParameter(type, () => type);
        }

        private static void ExpressionMessageTest(string type)
        {
            Guard.NullParameter(type, () => type, "A message");
        }
    }
}
