using FluentValidation.TestHelper;
using Trucks.Application.CreateTruck;
using Xunit;

namespace Trucks.UnitTest.CreateTruckTest
{
    public class CreateTruckCommandValidatorUnitTest
    {
        private readonly CreateTruckCommandValidator _validator;

        public CreateTruckCommandValidatorUnitTest()
        {
            _validator = new CreateTruckCommandValidator();
        }

        [Fact]
        public void Validate_Name_ShouldHaveValidationErrorWhenNameIsNull()
        {
            // Act
            var result = _validator.TestValidate(new CreateTruckCommand(null, "ValidModel",2024, "ValidChassis", "ValidColor"));

            // Assert
            result.ShouldHaveValidationErrorFor(command => command.Name);
        }

        [Fact]
        public void Validate_Name_ShouldHaveValidationErrorWhenNameIsEmpty()
        {
            // Act
            var result = _validator.TestValidate(new CreateTruckCommand("", "ValidModel", 2024, "ValidChassis", "ValidColor"));

            // Assert
            result.ShouldHaveValidationErrorFor(command => command.Name);
        }

        [Fact]
        public void Validate_Name_ShouldHaveValidationErrorWhenNameIsTooLong()
        {
            // Act
            var result = _validator.TestValidate(new CreateTruckCommand("This is a very long string that is definitely more than one hundred characters long. It is so long that it will definitely exceed the maximum length.", "ValidModel", 2024, "ValidChassis", "ValidColor"));

            // Assert
            result.ShouldHaveValidationErrorFor(command => command.Name);
        }

    }
}
