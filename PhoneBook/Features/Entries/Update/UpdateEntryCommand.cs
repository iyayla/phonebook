using MediatR;
using PhoneBook.Shared;

namespace PhoneBook.Features.Entries.Update;

public record UpdateEntryCommand(Guid Id, string FirstName, string LastName, string PhoneNumber) : IRequest<ApiResponse<Guid>>;
