using MediatR;
using PhoneBook.Shared;

namespace PhoneBook.Features.Entries.Update;

public static class UpdateEntryCommandEndpoint
{
    public static RouteGroupBuilder UpdateEntryGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapPut("/",
                async (UpdateEntryCommand command, IMediator mediator) =>
                {
                    var result = await mediator.Send(command);
                    return Results.Ok(result);
                })
            .AddEndpointFilter<ValidationFilter<UpdateEntryCommand>>()
            ;

        return group;
    }
}
