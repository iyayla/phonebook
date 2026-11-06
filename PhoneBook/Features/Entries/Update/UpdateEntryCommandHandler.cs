using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Repositories;
using PhoneBook.Shared;

namespace PhoneBook.Features.Entries.Update;

public class UpdateEntryCommandHandler(AppDbContext context) : IRequestHandler<UpdateEntryCommand, ApiResponse<Guid>>
{
    public async Task<ApiResponse<Guid>> Handle(UpdateEntryCommand request, CancellationToken cancellationToken)
    {
        var entry = await context.Entries.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entry == null) return ApiResponse<Guid>.ErrorResult("No item was found");

        entry.FirstName = request.FirstName;
        entry.LastName = request.LastName;
        entry.PhoneNumber = request.PhoneNumber;
        entry.LastModified = DateTime.UtcNow;

        context.Entries.Update(entry);

        await context.SaveChangesAsync(cancellationToken);

        return ApiResponse<Guid>.SuccessResult(request.Id);
    }
}
