using Vogen;

[assembly: VogenDefaults(
    conversions: Conversions.EfCoreValueConverter | Conversions.SystemTextJson,  // Converters for database storage and retrieval and for json serialization and deserialization
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