using System;
using System.Collections.Generic;
using System.Text;
using MultiTenantInventoryAPI.Domain.Aggregates.SubscriptionTypeAggregate;

namespace MultiTenantInventoryAPI.UnitTests.Domain.Aggregates.SubscriptionTypeAggregate;

public class SubscriptionTypeIdFrom
{
    [Fact]
    public void CreatesGivenValidValue()
    {
        int validValue = 1;
        SubscriptionTypeId subscriptionTypeId = SubscriptionTypeId.From(validValue);

        (subscriptionTypeId.Value).Equals(validValue);
    }
}
