namespace MultiTenantInventoryAPI.Core;

public abstract class EntityWithId<T, TId>
    where T: EntityWithId<T, TId>
{
    public TId Id { get; protected set; } = default!;
}