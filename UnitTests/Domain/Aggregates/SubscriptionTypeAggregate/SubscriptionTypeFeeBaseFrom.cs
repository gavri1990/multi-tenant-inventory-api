namespace MultiTenantInventoryAPI.UnitTests.Domain.Aggregates.SubscriptionTypeAggregate;

public class SubscriptionTypeFeeBaseFrom
{
    [Fact]
    public void CreatesGivenValidValue()
    {
        decimal validValue = 249.99m;
        SubscriptionTypeFeeBase subscriptionTypeFeeBase = SubscriptionTypeFeeBase.From(validValue);
        (subscriptionTypeFeeBase.Value).Equals(validValue);
    }

    [Theory]
    [InlineData(-1)]
    public void ThrowGivenInvalidValue(decimal invalidValue)
    {
        Action action = () =>
        {
            SubscriptionTypeFeeBase subscriptionTypeFeeBase = SubscriptionTypeFeeBase.From(invalidValue);
        };

        action.Should().Throw<Vogen.ValueObjectValidationException>();
    }
}
