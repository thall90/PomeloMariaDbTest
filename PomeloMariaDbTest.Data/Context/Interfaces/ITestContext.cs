namespace PomeloMariaDbTest.Data.Context.Interfaces;

public interface ITestContext : IDbContext
{
    DbSet<TestReadModel> Tests { get; set; }
}
