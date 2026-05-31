using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using MultiTenantInventoryAPI.Core.Aggregates.SubscriptionTypeAggregate;
using MultiTenantInventoryAPI.Core.Interfaces;
using MultiTenantInventoryAPI.Core.SeedWork;
using MultiTenantInventoryAPI.Infrastructure.Data;

namespace MultiTenantInventoryAPI.Infrastructure.Repositories;

public class SubscriptionTypeRepository: ISubscriptionTypeRepository
{
    private readonly AppDbContext _context;
    public IUnitOfWork UnitOfWork => _context;  //exposing the context

    public SubscriptionTypeRepository(AppDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<IEnumerable<SubscriptionType>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SubscriptionTypes.
            ToListAsync(cancellationToken);
    }
    public async Task<SubscriptionType?> GetByIdAsync(SubscriptionTypeId id, CancellationToken cancellationToken = default)
    {
        return await _context.SubscriptionTypes.
            FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
    public async Task<SubscriptionType?> GetByNameAsync(SubscriptionTypeName name, CancellationToken cancellationToken = default)
    {
        return await _context.SubscriptionTypes.
            FirstOrDefaultAsync(x => x.Name == name, cancellationToken);
    }
    public void Add(SubscriptionType entityWithId)
    {
        _context.SubscriptionTypes.Add(entityWithId);
    }
    public void Remove(SubscriptionType entityWithId)
    {
        _context.SubscriptionTypes.Remove(entityWithId);
    }
}
