using Vogen;

[assembly: VogenDefaults(
    staticAbstractsGeneration: StaticAbstractsGeneration.MostCommon | StaticAbstractsGeneration.InstanceMethodsAndProperties)]

namespace MultiTenantInventoryAPI.Core.Aggregates.SubscriptionTypeAggregate;

[ValueObject<int>]
public readonly partial struct SubscriptionTypeId
{    
    private static Validation Validate(int id)
        => id > 0 
        ? Validation.Ok 
        : Validation.Invalid("SubscriptionTypeId must be positive"); 
}
