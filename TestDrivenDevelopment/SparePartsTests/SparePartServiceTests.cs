using FluentAssertions;
using Moq;
using SomeWebApi.Controllers;

namespace SparePartsTests
{
    public class SparePartServiceTests
    {
        [Fact]
        public void SparePartService_saves_part_if_name_valid()
        {
            var sparePartRepositoryMock = new Mock<ISparePartRepository>();
            var validNameServiceMock = new Mock<IValidNameService>();

            validNameServiceMock
                .Setup(x=>x.IsValid(It.IsAny<string>()))
                .Returns(true);

            var service = new SparePartService(sparePartRepositoryMock.Object,
                validNameServiceMock.Object);

            var model = new SparePartCreateModel
            {
                Name = "SomeName"
            };

            service.CreateNewPart(model);

            sparePartRepositoryMock.Verify(x => x.Save(It.IsAny<SparePart>()), Times.Once);
        }

        [Fact]
        public void SparePartService_throws_exception_if_name_invalid()
        {
            var sparePartRepositoryMock = new Mock<ISparePartRepository>();
            var validNameServiceMock = new Mock<IValidNameService>();

            validNameServiceMock
                .Setup(x => x.IsValid(It.IsAny<string>()))
                .Returns(false);

            var service = new SparePartService(sparePartRepositoryMock.Object,
                validNameServiceMock.Object);

            var model = new SparePartCreateModel
            {
                Name = "SomeName"
            };

            Action action = () => service.CreateNewPart(model);

            action.Should().Throw<InvalidOperationException>();
            sparePartRepositoryMock.Verify(x => x.Save(It.IsAny<SparePart>()), Times.Never);
        }
    }
}