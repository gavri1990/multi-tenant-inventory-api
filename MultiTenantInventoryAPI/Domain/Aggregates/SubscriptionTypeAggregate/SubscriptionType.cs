using Microsoft.Identity.Client;

namespace MultiTenantInventoryAPI.Domain.Aggregates.SubscriptionTypeAggregate
{
    public class SubscriptionType
    {
        // Private constructor for EF Core
        private SubscriptionType() { }

        public SubscriptionType(string name) 
        { 
            
        }

        public string Name { get; private set; } = string.Empty; //Saves from errors regarding a null string
    }
}
