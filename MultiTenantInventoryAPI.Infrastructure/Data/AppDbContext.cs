using System.Reflection;
using MultiTenantInventoryAPI.Core.Aggregates.SubscriptionTypeAggregate;

namespace MultiTenantInventoryAPI.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options): DbContext(options)
{
    public DbSet<SubscriptionType> SubscriptionTypes => Set<SubscriptionType>();    //expression-bodied read-only property

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            entity.SetTableName(entity.DisplayName());  //avoiding turning the name to plural by preserving the exact name of the entity
        }
    }
}
