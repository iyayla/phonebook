using MediatR;
using PhoneBook.Shared;

namespace PhoneBook.Features.Entries.Create;

public record CreateEntryCommand(string FirstName, string LastName, string PhoneNumber) : IRequest<ApiResponse<CreateEntryResponse>>;
