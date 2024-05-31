using MediatR;
using Trucks.Application.Results;
using Trucks.Domain.Entities;
using Trucks.Domain.Repositories;

namespace Trucks.Application.CreateTruck;

public class CreateTruckCommandHandler(CreateTruckCommandValidator _validator, IRepository<Truck> _repository) : IRequestHandler<CreateTruckCommand, Result>
{
    public async Task<Result> Handle(CreateTruckCommand request, CancellationToken cancellationToken)
    {
        var isValid = await _validator.ValidateAsync(request, cancellationToken);
        if (!isValid.IsValid)
        {
            return new Result(false, "Invalid data", isValid.Errors);
        }

        var truck = new Truck(request.Name, request.Model, request.Year, request.Chassis, request.Color);
        await _repository.AddAsync(truck, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);

        return new Result(true, "Truck created successfully", truck.Id);

    }
}
