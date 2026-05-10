using Vogen;

[assembly: VogenDefaults(
    conversions: Conversions.EfCoreValueConverter,  // Generates the converter for all Value Objects
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
