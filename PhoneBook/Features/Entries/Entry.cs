using PhoneBook.Repositories;

namespace PhoneBook.Features.Entries;

public class Entry : BaseEntity
{
    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string PhoneNumber { get; set; } = default!;

    public DateTime DateCreated { get; set; }

    public DateTime LastModified { get; set; }
}
