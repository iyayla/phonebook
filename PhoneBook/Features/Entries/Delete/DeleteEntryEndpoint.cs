using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Repositories;
using PhoneBook.Shared;

namespace PhoneBook.Features.Entries.Delete;

public record DeleteEntryCommand(Guid Id) : IRequest<ApiResponse<bool>>;

public class DeleteEntryCommandHandler(AppDbContext context) : IRequestHandler<DeleteEntryCommand, ApiResponse<bool>>
{
    public async Task<ApiResponse<bool>> Handle(DeleteEntryCommand request, CancellationToken cancellationToken)
    {
        var entry = await context.Entries.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (entry == null)
            return ApiResponse<bool>.ErrorResult("No item was found");

        context.Entries.Remove(entry);
        await context.SaveChangesAsync(cancellationToken);

        return ApiResponse<bool>.SuccessResult(true);
    }
}

public static class DeleteEntryEndpoint
{
    public static RouteGroupBuilder DeleteEntryGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapDelete("/{id:guid}",
                async (IMediator mediator, Guid id) =>
                {
                    return Results.Ok(await mediator.Send(new DeleteEntryCommand(id)));
                })
            ;

        return group;
    }
}
