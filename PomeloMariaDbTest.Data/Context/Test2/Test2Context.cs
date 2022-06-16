using PomeloMariaDbTest.Data.Context.Test;
using PomeloMariaDbTest.Data.ReadModels.Test2;

namespace PomeloMariaDbTest.Data.Context.Test2;

public class Test2Context : DbContext, ITest2Context
{
    public Test2Context(DbContextOptions<Test2Context> options)
        : base(options)
    {
    }

    public DbSet<Test2ReadModel> Tests { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("Test2");
        modelBuilder.ApplyConfiguration(new Test2ReadModelConfiguration());
    }
}
