using Microsoft.EntityFrameworkCore;
using ENSC.Models;

namespace ENSC.Data;

public class ENSCContext : DbContext
{
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;
    public DbSet<Member> Members { get; set; } = null!;
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Group>()
        .HasIndex(b => b.Name)
        .IsUnique();


        modelBuilder.Entity<Student>()
        .HasIndex(b => b.EmailAdress)
        .IsUnique();

        modelBuilder.Entity<Member>()
            .HasKey(m => new { m.StudentId, m.GroupId });

        modelBuilder.Entity<Member>()
           .HasAlternateKey(m => new { m.GroupId, m.RoleId });


        modelBuilder.Entity<Member>()
            .HasOne(sg => sg.Student)
            .WithMany(s => s.Groups)
            .HasForeignKey(sg => sg.StudentId);

        modelBuilder.Entity<Member>()
            .HasOne(sg => sg.Group)
            .WithMany(g => g.Students)
            .HasForeignKey(sg => sg.GroupId);

        /*modelBuilder.Entity<Group>()
                    .HasOne(g => g.President)
                    .WithOne(s => s.Group)
                    .HasForeignKey<Student>(s => s.GroupId);

        modelBuilder.Entity<Student>()
                    .HasOne(g => g.Group)
                    .WithOne(s => s.President)
                    .HasPrincipalKey<Student>(g => g.Id)
                    .HasForeignKey<Group>(s => s.PresidentId)
                    .IsRequired();*/

    }

}