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
            .HasConversion(new SubscriptionTypeId.EfCoreValueConverter())
            .IsRequired();
    }
}
