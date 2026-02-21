using FluentAssertions;
using MultiTenantInventoryAPI.Domain.Aggregates.SubscriptionTypeAggregate;

namespace MultiTenantInventoryAPI.UnitTests.Domain.Aggregates.SubscriptionTypeAggregate;

public class SubscriptionTypeConstructor
{
    private readonly SubscriptionTypeName _testName = SubscriptionTypeName.From("testName");
    private readonly SubscriptionTypeFeeBase _testFeeBase = SubscriptionTypeFeeBase.From(125m);
    private SubscriptionType? _testSubscriptionType;

    private SubscriptionType CreateSubscriptionType()
    {
        return new SubscriptionType(_testName, _testFeeBase);
    }

    [Fact]
    public void InitializesName()
    {
        _testSubscriptionType = CreateSubscriptionType();

        _testSubscriptionType.Name.Should().Be(_testName);
    }
}
