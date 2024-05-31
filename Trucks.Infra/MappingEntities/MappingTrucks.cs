using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trucks.Domain.Entities;

namespace Trucks.Infra.MappingEntities;

public class MappingTrucks : MappingBaseEntity<Truck>
{
    public override void Configure(EntityTypeBuilder<Truck> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Name).HasMaxLength(128).IsRequired();
        builder.Property(x => x.Model).HasMaxLength(128).IsRequired();
        builder.Property(x => x.Year).IsRequired();
        builder.Property(x => x.Chassis).HasMaxLength(128).IsRequired();
        builder.Property(x => x.Color).HasMaxLength(128).IsRequired();
        
    }
}
