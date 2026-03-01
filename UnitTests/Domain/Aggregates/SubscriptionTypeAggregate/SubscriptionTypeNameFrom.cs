using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using MultiTenantInventoryAPI.Domain.Aggregates.SubscriptionTypeAggregate;

namespace MultiTenantInventoryAPI.UnitTests.Domain.Aggregates.SubscriptionTypeAggregate;

public class SubscriptionTypeNameFrom
{
    [Fact]
    public void CreatesGivenValidValue()
    {
        string? validValue = "monthly";
        SubscriptionTypeName subscriptionTypeName = SubscriptionTypeName.From(validValue);

        (subscriptionTypeName.Value).Should().Be(validValue);
    }


    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("A quiet breeze drifted through the open window, carrying with it the faint scent of pine and distant ocean waves")]
    public void ThrowsGivenInvalidValue(string? invalidValue)
    {
        Action action = () =>
        {
            SubscriptionTypeName subscriptionTypeName = SubscriptionTypeName.From(invalidValue!);
        };
             
        action.Should().Throw<Vogen.ValueObjectValidationException>();
    }
}
