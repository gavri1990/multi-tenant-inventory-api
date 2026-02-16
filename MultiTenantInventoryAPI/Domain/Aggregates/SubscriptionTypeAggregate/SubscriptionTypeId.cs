using Vogen;

namespace MultiTenantInventoryAPI.Domain.Aggregates.SubscriptionTypeAggregate;

[ValueObject<int>]
public readonly partial struct SubscriptionTypeId
{    
    private static Validation Validate(int value)
        => value > 0 ? Validation.Ok : Validation.Invalid("SubscriptionTypeId must be positive"); 
}
