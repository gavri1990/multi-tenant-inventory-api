using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTenantInventoryAPI.Core.Aggregates.SubscriptionTypeAggregate;
using Vogen;

namespace MultiTenantInventoryAPI.Infrastructure.Data.Config.SubscriptionTypes;

public class SubscriptionTypeConfiguration : IEntityTypeConfiguration<SubscriptionType>
{
    public void Configure(EntityTypeBuilder<SubscriptionType> builder)
    {
        builder.HasKey(entity => entity.Id); //EF Core would do it either way automatically, since the field is named exactly 'Id'

        builder.Property(entity => entity.Id)
            .HasValueGenerator<VogenIdValueGenerator<DbContext, SubscriptionType, SubscriptionTypeId>>()
            .HasVogenConversion()
            .IsRequired();

        builder.Property(entity => entity.Name)
            .HasMaxLength(SubscriptionTypeName.MaxLength)
            .HasVogenConversion()
            .IsRequired();

        builder.Property(entity => entity.FeeBase)
            .HasPrecision(18, 2)
            .HasVogenConversion()
            .IsRequired();

        builder.Property(entity => entity.IsActive)
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(entity => entity.CreatedAtUtc)
            .HasDefaultValueSql("SYSUTCDATETIME()") //Generates a 7-digit precision UTC. Centralized generation in the Database vs generation in each probable Web Server as insert order matters
            .ValueGeneratedOnAdd() //lets the Database generate the value on insert using the above statement (EF Core ignores the default value)
            .HasConversion(
                x => x,
                x => DateTime.SpecifyKind(x, DateTimeKind.Utc))
            .IsRequired().
            Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

        builder.Property(entity => entity.UpdatedAtUtc)
            .HasDefaultValueSql("SYSUTCDATETIME()")
            .ValueGeneratedOnAdd()  //only on initial addition. In an update, value will be set inside a domain object method by the web server handling the update
            .HasConversion(
                x => x,
                x => DateTime.SpecifyKind(x, DateTimeKind.Utc))
            .IsRequired();
    }
}
