namespace PomeloMariaDbTest.Data.Context.Interfaces;

public interface IDbContext
{
    IModel Model { get; }

    DatabaseFacade Database { get; }

    ChangeTracker ChangeTracker { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
