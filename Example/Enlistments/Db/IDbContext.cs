using Microsoft.EntityFrameworkCore;

namespace Example.Enlistments.Db;

public interface IDbContext
{
    DbSet<Account> Accounts { get; }
}