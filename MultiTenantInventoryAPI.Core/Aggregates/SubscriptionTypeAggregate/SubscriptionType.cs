namespace MultiTenantInventoryAPI.Core.Aggregates.SubscriptionTypeAggregate;

public class SubscriptionType(SubscriptionTypeName name, SubscriptionTypeFeeBase feeBase, bool isActive): 
    EntityWithId<SubscriptionType, SubscriptionTypeId>, IAggregateRoot
{
    public SubscriptionTypeName Name { get; private set; } = name;
    public SubscriptionTypeFeeBase FeeBase { get; private set; } = feeBase;
    public bool IsActive { get; private set; } = isActive;
    public DateTime CreatedAtUtc { get; private set; }
    public DateTime UpdatedAtUtc { get; private set; }


    public SubscriptionType UpdateName(SubscriptionTypeName newName)
    {
        if (Name == newName)
            return this;
        Name = newName;
        UpdatedAtUtc = DateTime.UtcNow;
        return this;
    }

    public SubscriptionType UpdateFeeBase(decimal newFeeBase)
    {
        if (FeeBase == newFeeBase)
            return this;
        FeeBase = SubscriptionTypeFeeBase.From(newFeeBase);
        UpdatedAtUtc = DateTime.UtcNow;
        return this;
    }

    public SubscriptionType UpdateIsActive(bool newIsActive)
    {
        if (IsActive == newIsActive) 
            return this;
        IsActive = newIsActive;
        UpdatedAtUtc = DateTime.UtcNow;
        return this;
    }
}
