using Domain.ValueObjects;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration; 

public class BankDetailsConfiguration : IEntityTypeConfiguration<BankDetails> {
    public void Configure(EntityTypeBuilder<BankDetails> builder) {
        builder.ToTable("bankDetails");
        builder.Property<int>("id")
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.HasKey("id");
    }
}