using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;
using PhoneBook.Features.Entries;

namespace PhoneBook.Repositories;

public class EntryEntityConfiguration : IEntityTypeConfiguration<Entry>
{
    public void Configure(EntityTypeBuilder<Entry> builder)
    {
        builder.ToCollection("entries");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.FirstName).HasElementName("firstName").HasMaxLength(255);
        builder.Property(x => x.LastName).HasElementName("lastName").HasMaxLength(255);
        builder.Property(x => x.PhoneNumber).HasElementName("phoneNumber").HasMaxLength(255);
        builder.Property(x => x.DateCreated).HasElementName("dateCreated");
        builder.Property(x => x.LastModified).HasElementName("lastModified");
    }
}
