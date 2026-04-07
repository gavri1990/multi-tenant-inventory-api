using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
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

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public void ThrowsGivenInvalidValue(int invalidValue)
    {
        Action action = () => 
        {
            SubscriptionTypeId subscriptionTypeId = SubscriptionTypeId.From(invalidValue!);
        };

        action.Should().Throw<Vogen.ValueObjectValidationException>();
    }
}
