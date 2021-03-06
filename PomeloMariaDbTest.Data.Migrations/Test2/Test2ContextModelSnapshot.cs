// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PomeloMariaDbTest.Data.Context.Test2;

#nullable disable

namespace PomeloMariaDbTest.Data.Migrations.Test2
{
    [DbContext(typeof(Test2Context))]
    partial class Test2ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Test")
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PomeloMariaDbTest.Data.ReadModels.Test2.Test2ReadModel", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("Derp")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("CustomerId", "Id")
                        .HasName("PK_Test");

                    b.ToTable("Tests", "Test");
                });
#pragma warning restore 612, 618
        }
    }
}
