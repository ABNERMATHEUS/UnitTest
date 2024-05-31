using MediatR;
using Trucks.Application.Results;

namespace Trucks.Application.CreateTruck;

public record CreateTruckCommand(string Name, string Model, int Year, string Chassis, string Color) : IRequest<Result>;