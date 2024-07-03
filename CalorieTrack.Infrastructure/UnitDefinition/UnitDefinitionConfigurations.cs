using CalorieTrack.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalorieTrack.Infrastructure;

public class UnitDefinitionConfigurations: IEntityTypeConfiguration<UnitDefinition>
{
    public void Configure(EntityTypeBuilder<UnitDefinition> builder)
    {
        builder
            .HasOne(ud => ud.Nutrition)
            .WithOne(n => n.UnitDefinition)
            .HasForeignKey<Nutrition>(n => n.UnitDefinitionGuid);
    }
    
}