namespace PhoneBook.Features.Entries.Dtos;

public record EntryDto(Guid Id, string FirstName, string LastName, string PhoneNumber, DateTime DateCreated, DateTime LastModified);
