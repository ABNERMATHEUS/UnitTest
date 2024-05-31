using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Trucks.Application.CreateTruck;
using Trucks.Domain.Repositories;
using Trucks.Infra.Context;
using Trucks.Infra.Repositories;

namespace Trucks.API.Configuration;

public static class ConfigurationAPI 
{
    public static IServiceCollection AddConfigurations(this IServiceCollection services)
    {
        // Adds and configures the DbContextTrucks (which is your Entity Framework Core context) to use an in-memory database. 
        // This is typically used for testing or development due to the volatile nature of the in-memory database.
        services.AddDbContext<DbContextTrucks>(x => x.UseInMemoryDatabase(nameof(DbContextTrucks)));

        // Registers the generic repository interface IRepository<> and its implementation Repository<> to the services collection.
        // The AddScoped method means a new instance of the service will be created for each scope, i.e., each web request.
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        // Adds MediatR services (a library for in-process messaging) to the services collection.
        // It scans the assembly containing CreateTruckCommand for any classes that are handling requests (commands/queries).
        services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining(typeof(CreateTruckCommand)));

        // Adds FluentValidation services (a library for building strongly-typed validation rules) to the services collection.
        // It scans the assembly containing CreateTruckCommandValidator for any validation classes.
        services.AddValidatorsFromAssemblyContaining(typeof(CreateTruckCommandValidator));

        return services;
    }
}
