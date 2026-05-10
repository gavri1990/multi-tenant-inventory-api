namespace MultiTenantInventoryAPI.Core;

/// <summary>
/// Marker interface only for aggregate root entities in the domain model
/// The repository implementation can use constraints to ensure it only operates on aggregate roots
/// </summary>
public interface IAggregateRoot
{
}
