using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTenantInventoryAPI.Core.Aggregates.SubscriptionTypeAggregate;

namespace MultiTenantInventoryAPI.Infrastructure.Data.Config.SubscriptionTypes;

public class SubscriptionTypeConfiguration : IEntityTypeConfiguration<SubscriptionType>
{
    public void Configure(EntityTypeBuilder<SubscriptionType> builder)
    {
        
    }
}
