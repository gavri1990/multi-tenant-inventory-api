using MultiTenantInventoryAPI.Core.Aggregates.SubscriptionTypeAggregate;
using MultiTenantInventoryAPI.Core.SeedWork;

namespace MultiTenantInventoryAPI.Core.Interfaces;

public interface ISubscriptionTypeRepository: IRepository<SubscriptionType, SubscriptionTypeId>
{
    Task<SubscriptionType?> GetByNameAsync(SubscriptionTypeName name, CancellationToken cancellation = default);
}
