using FluentAssertions;
using Xunit;

namespace SharpBoard.Tests
{
    public class DummyTest
    {
        [Fact]
        public void Dummy() => true.Should().Be(true);
    }
}
