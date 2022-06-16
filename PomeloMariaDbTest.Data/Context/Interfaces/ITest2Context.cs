using PomeloMariaDbTest.Data.ReadModels.Test2;

namespace PomeloMariaDbTest.Data.Context.Interfaces;

public interface ITest2Context : IDbContext
{
    DbSet<Test2ReadModel> Tests { get; set; }
}
