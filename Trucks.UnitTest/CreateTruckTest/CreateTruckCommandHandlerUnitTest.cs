using Moq;
using Trucks.Application.CreateTruck;
using Trucks.Domain.Entities;
using Trucks.Domain.Repositories;

namespace Trucks.UnitTest.CreateTruckTest;

public class CreateTruckCommandHandlerUnitTest
{
    private readonly CreateTruckCommandValidator _validator;
    private readonly Mock<IRepository<Truck>> _repositoryMock;
    private readonly CreateTruckCommandHandler _handler;

    public CreateTruckCommandHandlerUnitTest()
    {
        _validator = new CreateTruckCommandValidator();
        _repositoryMock = new Mock<IRepository<Truck>>();
        _handler = new CreateTruckCommandHandler(_validator, _repositoryMock.Object);
    }

    // Fact is used when the test will always have the same result
    [Fact]
    [Trait("Category", "Truck")]
    public async Task Handle_ValidRequest_ShouldReturnSuccessResult()
    {
        // Arrange
        var request = new CreateTruckCommand("Test", "Model", 2022, "Chassis", "Color");

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.True(result.Success);
        Assert.Equal("Truck created successfully", result.Message);

    }

    // Theory is used when the test can have different results depending on the input data
    [Theory]
    [InlineData(null, "Model", 2022, "Chassis", "White")]
    [InlineData("Test", null, 2022, "Chassis", "Black")]
    [InlineData("Test", "Model", 2024, "Chassis", "")]
    [InlineData("Test", "Model", 2022, null, "Blue")]
    [InlineData("Test", "Model", 2022, "", "Red")]
    [Trait("Category", "Truck")]
    public async Task Handle_InvalidRequest_ShouldReturnFailureResult(string name, string model, int year, string chassis, string color)
    {
        // Arrange
        var request = new CreateTruckCommand(name, model, year, chassis, color);

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.False(result.Success);
        Assert.Equal("Invalid data", result.Message);

    }
}
