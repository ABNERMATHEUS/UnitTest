using MediatR;
using Trucks.Application.Results;
using Trucks.Domain.Entities;
using Trucks.Domain.Repositories;

namespace Trucks.Application.DeleteTruck;

public class DeleteTruckCommandHandler(IRepository<Truck> _repository, DeleteTruckCommandValidator _validator) : IRequestHandler<DeleteTruckCommand, Result>
{
    public async Task<Result> Handle(DeleteTruckCommand request, CancellationToken cancellationToken)
    {
        var isValid = await _validator.ValidateAsync(request, cancellationToken);
        if (!isValid.IsValid)
        {
            return new Result(false, "Invalid data", isValid.Errors);
        }
        var truck = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (truck is null)
        {
            return new Result(false, "Truck not found");
        }

        _repository.Delete(truck);
        await _repository.SaveChangesAsync(cancellationToken);
        return new Result(true, "Truck deleted successfully", truck.Id);
    }
}
