using MultiTenantInventoryAPI.Domain.Aggregates.SubscriptionTypeAggregate;

namespace MultiTenantInventoryAPI.Features.SubscriptionTypeFeatures;

public record SubscriptionTypeDTO(SubscriptionTypeName Name, SubscriptionTypeFeeBase FeeBase, bool IsActive);
