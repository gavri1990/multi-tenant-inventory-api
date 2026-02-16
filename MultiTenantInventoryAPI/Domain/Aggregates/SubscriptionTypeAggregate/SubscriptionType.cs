namespace MultiTenantInventoryAPI.Domain.Aggregates.SubscriptionTypeAggregate;

public class SubscriptionType(SubscriptionTypeName name, decimal feeBase)
{
    public SubscriptionTypeId Id { get; private set; }
    public SubscriptionTypeName Name { get; private set; } = name;
    public decimal FeeBase { get; private set; } = feeBase;
    public bool IsActive { get; private set; } = true;
    public DateTime CreatedAtUtc { get; private set; } = DateTime.UtcNow;
    public DateTime UpdatedAtUtc { get; private set; } = DateTime.UtcNow;


    public SubscriptionType UpdateName(SubscriptionTypeName newName)
    {
        if (Name == newName)
            return this;
        Name = newName;
        UpdatedAtUtc = DateTime.UtcNow;
        return this;
    }
}
