using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PomeloMariaDbTest.Data.ReadModels.Test2;

public class Test2ReadModelConfiguration : IEntityTypeConfiguration<Test2ReadModel>
{
    public void Configure(EntityTypeBuilder<Test2ReadModel> builder)
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
