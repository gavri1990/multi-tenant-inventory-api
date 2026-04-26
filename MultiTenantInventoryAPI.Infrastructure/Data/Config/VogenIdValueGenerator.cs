using System.Reflection;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using MultiTenantInventoryAPI.Core;

namespace MultiTenantInventoryAPI.Infrastructure.Data.Config;

internal class VogenIdValueGenerator<TContext, TEntityWithId, TId>: ValueGenerator<TId>
    where TContext : DbContext
    where TEntityWithId : EntityWithId<TEntityWithId, TId>
    where TId : IVogen<TId, int>
{
    private readonly PropertyInfo _matchPropertyGetter;

    public VogenIdValueGenerator()
    {
        var matchingProperties =
            typeof(TContext).GetProperties().Where(p => p!.GetGetMethod()!.IsPublic && p.PropertyType == typeof(DbSet<TEntityWithId>)).ToList();

        if(matchingProperties.Count == 0)
        {
            throw new InvalidOperationException($"No properties found in the EFCore context for a DBSet of {nameof(TEntityWithId)}");
        }

        if(matchingProperties.Count > 1)
        {
            throw new InvalidOperationException($"Multiple properties found in the EFCore context for a DBSet of {nameof(TEntityWithId)}");
        }

        _matchPropertyGetter = matchingProperties[0]; //if no exceptions, it will be exactly one, in the first position
    }

    public override TId Next(EntityEntry entry)
    {
        TContext ctx = (TContext)entry.Context;

        DbSet<TEntityWithId> entities = (DbSet<TEntityWithId>)_matchPropertyGetter!.GetValue(ctx)!;

        var next = Math.Max(
                MaxFrom(entities.Local),
                MaxFrom(entities)) + 1;

        return TId.From(next);

        static int MaxFrom(IEnumerable<TEntityWithId> es) =>
            es.Any() ? es.Max(e => e.Id.Value) : 0;
    }

    public override bool GeneratesTemporaryValues => false;
}
