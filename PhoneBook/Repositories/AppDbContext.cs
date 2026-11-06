using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using PhoneBook.Features.Entries;
using System.Reflection;

namespace PhoneBook.Repositories;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Entry> Entries { get; set; }

    public static AppDbContext Create(IMongoDatabase database)
    {
        var optionsBuilder =
            new DbContextOptionsBuilder<AppDbContext>().UseMongoDB(database.Client,
                database.DatabaseNamespace.DatabaseName);


        return new AppDbContext(optionsBuilder.Options);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
