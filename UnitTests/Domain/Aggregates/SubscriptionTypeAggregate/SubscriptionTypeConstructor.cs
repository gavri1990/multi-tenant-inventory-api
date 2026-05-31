namespace MultiTenantInventoryAPI.UnitTests.Domain.Aggregates.SubscriptionTypeAggregate;

public class SubscriptionTypeConstructor
{
    private readonly SubscriptionTypeName _testName = SubscriptionTypeName.From("testName");
    private readonly SubscriptionTypeFeeBase _testFeeBase = SubscriptionTypeFeeBase.From(125m);
    private readonly bool _testIsActive = true;
    private SubscriptionType? _testSubscriptionType;

    private SubscriptionType CreateSubscriptionType()
    {
        return new SubscriptionType(_testName, _testFeeBase, _testIsActive);
    }

    [Fact]
    public void InitializesName()
    {
        _testSubscriptionType = CreateSubscriptionType();

        _testSubscriptionType.Name.Should().Be(_testName);
    }


    [Fact]
    public void InitializesFeeBase()
    {
        _testSubscriptionType = CreateSubscriptionType();

        _testSubscriptionType.FeeBase.Should().Be(_testFeeBase);
    }
}
