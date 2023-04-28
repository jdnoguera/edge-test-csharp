
using Microsoft.EntityFrameworkCore;

namespace backend_test;

public class DBContext: DbContext
{
    public DbSet<Customer> Customer { get; set; }
    
    public string DbPath { get; }

    public DBContext()
    {
        const Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "test.db");
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}