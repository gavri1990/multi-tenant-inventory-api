using System;
using System.Collections.Generic;
using System.Text;

namespace MultiTenantInventoryAPI.Core.SeedWork;

public interface IRepository<T> where T: class, IAggregateRoot //reference type that implements IAggregateRoot marker interface
{
    IUnitOfWork UnitOfWork { get; }  //the implementing class must have a property that implements IUnitOfWork

    Task AddAsync(T entity, CancellationToken cancellationToken);
    void Remove(T entity);
}
