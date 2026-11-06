using MassTransit;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Features.Entries;

namespace PhoneBook.Repositories;

public static class SeedData
{
    public static async Task AddSeedDataExt(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        dbContext.Database.AutoTransactionBehavior = AutoTransactionBehavior.Never;

        if (await dbContext.Entries.AnyAsync())
            return;

        var entries = new List<Entry>
        {
            new() {
                Id = NewId.NextSequentialGuid(),
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "1234567890",
                DateCreated = DateTime.UtcNow,
                LastModified = DateTime.UtcNow,
            },
            new()
            {
                Id = NewId.NextSequentialGuid(),
                FirstName = "Jane",
                LastName = "Doe",
                PhoneNumber = "2345678901",
                DateCreated = DateTime.UtcNow,
                LastModified = DateTime.UtcNow,
            }
        };


        dbContext.Entries.AddRange(entries);
        await dbContext.SaveChangesAsync();

    }
}
