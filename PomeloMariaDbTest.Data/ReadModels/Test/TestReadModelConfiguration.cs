using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PomeloMariaDbTest.Data.ReadModels.Test;

public class TestReadModelConfiguration : IEntityTypeConfiguration<TestReadModel>
{
    public void Configure(EntityTypeBuilder<TestReadModel> builder)
    {
        builder.HasKey(x => new { x.CustomerId, x.Id })
            .HasName("PK_Test");

        builder.Property(x => x.CustomerId)
            .IsRequired()
            .ValueGeneratedNever();

        builder.Property(x => x.Id)
            .IsRequired()
            .ValueGeneratedNever();

        builder.Property(x => x.Derp)
            .IsRequired(false)
            .IsUnicode(false)
            .HasMaxLength(50);
    }
}
