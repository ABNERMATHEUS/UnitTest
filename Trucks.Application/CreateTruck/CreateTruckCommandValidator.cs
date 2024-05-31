using FluentValidation;

namespace Trucks.Application.CreateTruck;

public class CreateTruckCommandValidator : AbstractValidator<CreateTruckCommand>
{
    public CreateTruckCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Model).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Chassis).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Color).NotEmpty().MaximumLength(100);
    }
}
