namespace PomeloMariaDbTest.Data.Context.Test;

public class TestContext : DbContext, ITestContext
{
    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    public DbSet<TestReadModel> Tests { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("Test");
        modelBuilder.ApplyConfiguration(new TestReadModelConfiguration());
    }
}
