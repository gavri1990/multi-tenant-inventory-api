namespace MultiTenantInventoryAPI.Core.SeedWork;

public interface IRepository<T, TId> where T: EntityWithId<T, TId>, IAggregateRoot //reference type that implements IAggregateRoot marker interface
{
    IUnitOfWork UnitOfWork { get; }  //the implementing class must have a property that implements IUnitOfWork
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<T?> GetByIdAsync(TId id, CancellationToken cancellation = default);
    //since vogen generates the ids, there will be no newtork call to the db for database generation,
    //so no async nor cancellation token needed in the Add method below
    void Add(T entityWithId); 
    void Remove(T entityWithId);
}