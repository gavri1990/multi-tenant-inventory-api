using Vogen;

[ValueObject<decimal>]
public partial struct SubscriptionTypeFeeBase
{
    private static Validation Validate(decimal feeBase)
        => feeBase >= 0 
        ? Validation.Ok 
        : Validation.Invalid("SubscriptionTypeFeeBase must be 0 or positive");
}