using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTenantInventoryAPI.Core.Aggregates.SubscriptionTypeAggregate;
using Vogen;

namespace MultiTenantInventoryAPI.Infrastructure.Data.Config.SubscriptionTypes;

public class SubscriptionTypeConfiguration : IEntityTypeConfiguration<SubscriptionType>
{
    public void Configure(EntityTypeBuilder<SubscriptionType> builder)
    {
        builder.Property(entity => entity.Id)
            .HasValueGenerator<VogenIdValueGenerator<DbContext, SubscriptionType, SubscriptionTypeId>>()
            .HasVogenConversion()
            .IsRequired();

        builder.Property(entity => entity.Name)
            .HasMaxLength(SubscriptionTypeName.MaxLength)
            .HasVogenConversion()
            .IsRequired();

        builder.Property(entity => entity.FeeBase)
            .HasPrecision(18, 2)
            .HasVogenConversion()
            .IsRequired();

        builder.Property(entity => entity.IsActive)
            .HasDefaultValue(true)
            .IsRequired();
    }
}
