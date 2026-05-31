namespace MultiTenantInventoryAPI.Core.SeedWork;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default); //AppDbContext will just implement the interface and due to naming match, the method is considered as implemented automatically
}
