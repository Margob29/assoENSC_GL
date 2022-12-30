using Microsoft.EntityFrameworkCore;
using ENSC.Models;

namespace ENSC.Data;

public class ENSCContext : DbContext
{
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Event> Events { get; set; } = null!;
    public DbSet<Group> Groups { get; set; } = null!;
    public DbSet<GroupViewer> GroupViewers { get; set; } = null!;
    public string DbPath { get; private set; }

    public ENSCContext()
    {
        // Path to SQLite database file
        DbPath = "ENSC.db";
    }

    // The following configures EF to create a SQLite database file locally
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // Use SQLite as database
        options.UseSqlite($"Data Source={DbPath}");
        // Optional: log SQL queries to console
        options.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
    }
}