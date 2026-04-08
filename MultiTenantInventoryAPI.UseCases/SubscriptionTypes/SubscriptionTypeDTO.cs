using MultiTenantInventoryAPI.Core.Aggregates.SubscriptionTypeAggregate;

namespace MultiTenantInventoryAPI.UseCases.SubscriptionTypes;

public record SubscriptionTypeDTO(SubscriptionTypeName Name, SubscriptionTypeFeeBase FeeBase, bool IsActive);
