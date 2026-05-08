using DeepSeekAgent.Models;
using Microsoft.EntityFrameworkCore;

namespace DeepSeekAgent;

public class AppDatabaseContext : DbContext
{
    public DbSet<DeepSeekToken> DeepSeekTokens { get; set; } = null!;

    public AppDatabaseContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=app.db");
    }
}