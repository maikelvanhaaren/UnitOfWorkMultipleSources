using Microsoft.EntityFrameworkCore;

namespace Example.Enlistments.Db;

public class ExampleDbContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }

    public string DbPath { get; }

    public ExampleDbContext()
    {
        const Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "uow-example.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(c =>
        {
            c.HasKey(z => z.Email);
        });
    }
}