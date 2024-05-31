using MediatR;
using Trucks.Application.Results;

namespace Trucks.Application.DeleteTruck;

public record DeleteTruckCommand(Guid Id) : IRequest<Result>;
