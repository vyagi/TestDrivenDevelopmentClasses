using FluentAssertions;
using Geomtery;

namespace Geometry.Tests
{
    public class SegmentTests
    {
        [Fact]
        public void Segment_can_be_created()
        {
            var segment = new Segment(new Point(0, 0), new Point(1, 2));

            segment.Start.X.Should().Be(0);
            segment.Start.Y.Should().Be(0);
            segment.End.X.Should().Be(1);
            segment.End.Y.Should().Be(2);
        }

        [Fact]
        public void Segment_length_can_be_computed()
        {
            var segment = new Segment(new Point(1, 1), new Point(4, 5));

            segment.Length.Should().Be(5);
        }
    }
}
