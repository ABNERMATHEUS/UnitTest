using Microsoft.EntityFrameworkCore;
using Trucks.Infra.MappingEntities;

namespace Trucks.Infra.Context;

public class DbContextTrucks : DbContext
{
    public DbContextTrucks(DbContextOptions<DbContextTrucks> options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new MappingTrucks());
    }

}
