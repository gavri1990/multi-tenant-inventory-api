using MultiTenantInventoryAPI.Core.Aggregates.SubscriptionTypeAggregate;

namespace MultiTenantInventoryAPI.Infrastructure;

public class AppDbContext(DbContextOptions<AppDbContext> options): DbContext(options)
{
    public DbSet<SubscriptionType> SubscriptionTypes => Set<SubscriptionType>();    //expression-bodied read-only property
}
