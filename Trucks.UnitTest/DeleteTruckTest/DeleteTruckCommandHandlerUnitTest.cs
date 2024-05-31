using Moq;
using Trucks.Application.DeleteTruck;
using Trucks.Domain.Entities;
using Trucks.Domain.Repositories;

namespace Trucks.UnitTest.DeleteTruckTest
{
    public class DeleteTruckCommandHandlerUnitTest
    {
        private readonly DeleteTruckCommandValidator _validator;
        private readonly Mock<IRepository<Truck>> _repositoryMock;
        private readonly DeleteTruckCommandHandler _handler;

        public DeleteTruckCommandHandlerUnitTest()
        {
            _validator = new DeleteTruckCommandValidator();
            _repositoryMock = new Mock<IRepository<Truck>>();
            _handler = new DeleteTruckCommandHandler(_repositoryMock.Object, _validator);
        }

        [Fact]
        [Trait("Category", "Truck")]
        public async Task Handle_ValidRequest_ShouldReturnSuccessResult()
        {
            // Arrange
            var request = new DeleteTruckCommand(Guid.NewGuid());
            Truck? truck = new Truck("Test","VM",2024,"DASDDAS","Blue");
            _repositoryMock.Setup(r => r.GetByIdAsync(request.Id, It.IsAny<CancellationToken>())).ReturnsAsync(truck);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.True(result.Success);
            Assert.Equal("Truck deleted successfully", result.Message);
        }

        [Fact]
        [Trait("Category", "Truck")]

        public async Task Handle_ValidRequest_But_not_contain_ShouldReturnFailResult()
        {
            // Arrange
            var request = new DeleteTruckCommand(Guid.NewGuid());
            Truck truck = null;
            _repositoryMock.Setup(r => r.GetByIdAsync(request.Id, It.IsAny<CancellationToken>())).ReturnsAsync(truck);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.False(result.Success);
           
        }
    }
}
