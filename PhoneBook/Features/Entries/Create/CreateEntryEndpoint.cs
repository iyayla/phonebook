using MediatR;
using PhoneBook.Shared;

namespace PhoneBook.Features.Entries.Create;

public static class CreateEntryEndpoint
{
    public static RouteGroupBuilder CreateEntryGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapPost("/", async (CreateEntryCommand command, IMediator mediator) => {
            var result = await mediator.Send(command);
            return Results.Ok(result);
        })
            .AddEndpointFilter<ValidationFilter<CreateEntryCommand>>()
            ;

        return group;
    }
}
