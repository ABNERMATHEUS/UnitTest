using FluentValidation;

namespace Trucks.Application.DeleteTruck;

public class DeleteTruckCommandValidator : AbstractValidator<DeleteTruckCommand>
{
    public DeleteTruckCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}