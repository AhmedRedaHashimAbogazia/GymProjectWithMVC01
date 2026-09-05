using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCProject1.Models;

namespace MVCProject1.Context.Configuration;

public class PlanConfiguration : IEntityTypeConfiguration<Plan>
{
    public void Configure(EntityTypeBuilder<Plan> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired()
            .HasColumnType("varchar(100)");

        builder.Property(p => p.Description)
            .IsRequired()
            .HasColumnType("varchar(100)");

        builder.Property(p => p.Price)
            .HasPrecision(10, 2);

        // constraint: duration days is (1 - 365)
        // check constraint
        builder.ToTable(tp =>
        {
            tp.HasCheckConstraint("CK_Plan_DurationDays", "[DurationDays] >= 1 AND [DurationDays] <= 365");
        });
    }
}
