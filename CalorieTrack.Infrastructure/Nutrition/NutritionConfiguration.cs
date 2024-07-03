using CalorieTrack.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalorieTrack.Infrastructure;

public class NutritionConfiguration: IEntityTypeConfiguration<Nutrition>
{
    public void Configure(EntityTypeBuilder<Nutrition> builder)
    {
        builder
            .HasOne(n => n.UnitDefinition)
            .WithOne(ud => ud.Nutrition)
            .HasForeignKey<UnitDefinition>(ud => ud.NutritionGuid);
    }

}