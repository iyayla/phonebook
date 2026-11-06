using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Repositories;
using PhoneBook.Shared;

namespace PhoneBook.Features.Entries.Create;

public class CreateEntryCommandHandler(AppDbContext context) : IRequestHandler<CreateEntryCommand, ApiResponse<CreateEntryResponse>>
{
    public async Task<ApiResponse<CreateEntryResponse>> Handle(CreateEntryCommand request, CancellationToken cancellationToken)
    {
        var existingEntry = await context.Entries.AnyAsync(x => x.FirstName == request.FirstName && x.LastName == request.LastName, cancellationToken);

        if (existingEntry)
            return ApiResponse<CreateEntryResponse>.ErrorResult($"The person {request.FirstName} {request.LastName} already exists");

        var entry = new Entry
        {
            Id = NewId.NextSequentialGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            PhoneNumber = request.PhoneNumber,
            DateCreated = DateTime.UtcNow,
            LastModified = DateTime.UtcNow,
        };


        await context.Entries.AddAsync(entry, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);



        return ApiResponse<CreateEntryResponse>.SuccessResult(new CreateEntryResponse(entry.Id));
    }
}
