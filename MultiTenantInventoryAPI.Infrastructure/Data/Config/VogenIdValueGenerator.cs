using Microsoft.EntityFrameworkCore.ValueGeneration;
using MultiTenantInventoryAPI.Core;

namespace MultiTenantInventoryAPI.Infrastructure.Data.Config;

internal class VogenIdValueGenerator<TEntityContext, TEntityWithId, TId>: ValueGenerator<TId>
    where TEntityContext : DbContext
    where TEntityWithId : EntityWithId<TEntityWithId, TId>
    where TId : IVogen<TId, int>
{

    public VogenIdValueGenerator()
    {

    }

    public override bool GeneratesTemporaryValues => false;
}
