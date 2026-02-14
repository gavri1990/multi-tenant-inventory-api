using Vogen;

namespace MultiTenantInventoryAPI.Domain.Aggregates.SubscriptionTypeAggregate
{
    [ValueObject<int>]
    public readonly partial struct SubscriptionTypeId
    {
        /// <summary>
        /// Represents a new SubscriptionType that has not yet been persisted to the database.
        /// EF Core will assign the actual identity value on SaveChanges.
        /// </summary>
        public static SubscriptionTypeId New => From(0);

        private static Validation Validate(int value)
            => value >= 0 ? Validation.Ok : Validation.Invalid("SubscriptionTypeId must not be negative"); 
    }
}
