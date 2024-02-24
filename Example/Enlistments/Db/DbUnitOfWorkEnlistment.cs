using Example.UoW;
using Microsoft.EntityFrameworkCore;

namespace Example.Enlistments.Db;

public class DbUnitOfWorkEnlistment 
    : IUnitOfWorkEnlistment, IDbContext
{
    private readonly ExampleDbContext _ctx;
    
    public DbSet<Account> Accounts => _ctx.Accounts;

    public DbUnitOfWorkEnlistment()
    {
        _ctx = new ExampleDbContext();
        _ctx.Database.BeginTransaction();
    }

    public async Task PreCommitAsync() 
        => await _ctx.SaveChangesAsync();

    public async Task CommitAsync() 
        => await _ctx.Database.CommitTransactionAsync();

    public Task RollbackAsync() 
        => _ctx.Database.RollbackTransactionAsync();
}