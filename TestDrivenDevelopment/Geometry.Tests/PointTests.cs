using FluentAssertions;
using Geomtery;

namespace Geometry.Tests
{
    public class PointTests
    {
        [Fact]
        public void Point_can_be_created_and_expose_proper_coordinates()
        {
            var point = new Point();

            point.Should().NotBeNull();
            point.X.Should().Be(0);
            point.Y.Should().Be(0);
        }

        [Fact]
        public void Point_can_be_created_using_one_parameter()
        {
            var point = new Point(4.5);

            point.X.Should().Be(4.5);
            point.Y.Should().Be(4.5);
        }

        [Fact]
        public void Point_can_be_created_using_two_parameters()
        {
            var point = new Point(4.5, -5.5);

            point.X.Should().Be(4.5);
            point.Y.Should().Be(-5.5);
        }

        [Fact]
        public void Point_can_be_moved()
        {
            var point = new Point(4.5, -5.5);

            point.Move(-1, 2);

            point.X.Should().Be(3.5);
            point.Y.Should().Be(-3.5);
        }

        [Fact]
        public void Distance_can_be_computed()
        {
            var point = new Point(3, 4);

            point.Distance().Should().Be(5);
        }
    }
}
