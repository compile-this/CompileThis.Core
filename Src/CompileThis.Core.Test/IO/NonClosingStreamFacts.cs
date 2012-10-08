namespace CompileThis.IO
{
    using System;
    using System.IO;
    
    using FluentAssertions;

    using Xunit;

    public class NonClosingStreamFacts
    {
        [Fact]
        public void NonClosingStream_closing_stream_does_not_close_inner_stream()
        {
            using (var innerStream = new MemoryStream())
            {
                var outerStream = new NonClosingStream(innerStream);
                outerStream.Dispose();

                Action action = () => innerStream.WriteByte(0);

                action.ShouldNotThrow();
            }
        }

        [Fact]
        public void NonClosingStream_writes_to_stream_are_applied_to_inner_stream()
        {
            var innerStream = new MemoryStream();

            using (var outerStream = new NonClosingStream(innerStream))
            {
                outerStream.WriteByte(1);
                outerStream.WriteByte(2);
                outerStream.WriteByte(3);
            }

            innerStream.Length.Should().Be(3);
            innerStream.Dispose();
        }

        [Fact]
        public void NonClosingStream_reads_from_stream_are_applied_to_inner_stream()
        {
            var innerStream = new MemoryStream();
            innerStream.WriteByte(1);
            innerStream.WriteByte(2);
            innerStream.WriteByte(3);
            innerStream.Position = 0;

            using (var outerStream = new NonClosingStream(innerStream))
            {
                var buffer = new byte[3];
                outerStream.Read(buffer, 0, 3);

                buffer.Should().BeEquivalentTo(new byte[] {1, 2, 3});
            }

            innerStream.Dispose();
        }
    }
}
