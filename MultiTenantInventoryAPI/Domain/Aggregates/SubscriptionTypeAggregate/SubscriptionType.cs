namespace MultiTenantInventoryAPI.Domain.Aggregates.SubscriptionTypeAggregate;

public class SubscriptionType(SubscriptionTypeName name, SubscriptionTypeFeeBase feeBase)
{
    public SubscriptionTypeId Id { get; private set; }
    public SubscriptionTypeName Name { get; private set; } = name;
    public SubscriptionTypeFeeBase FeeBase { get; private set; } = feeBase;
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
