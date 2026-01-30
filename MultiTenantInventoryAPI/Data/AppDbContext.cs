using Microsoft.EntityFrameworkCore;

namespace MultiTenantInventoryAPI.Data
{
    public class AppDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
        }
    }
}
