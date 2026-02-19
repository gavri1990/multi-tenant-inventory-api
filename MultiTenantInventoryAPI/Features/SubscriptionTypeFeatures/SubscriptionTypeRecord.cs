using MultiTenantInventoryAPI.Domain.Aggregates.SubscriptionTypeAggregate;

namespace MultiTenantInventoryAPI.Features.SubscriptionTypeFeatures;

public record SubscriptionTypeRecord(string Name, decimal FeeBase, bool IsActive);