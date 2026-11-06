using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Features.Entries.Dtos;
using PhoneBook.Repositories;
using PhoneBook.Shared;

namespace PhoneBook.Features.Entries.GetAll;

public record GetAllEntriesQuery : IRequest<ApiResponse<List<EntryDto>>>;

public class GetAllEntriesQueryHandler(AppDbContext context, IMapper mapper)
    : IRequestHandler<GetAllEntriesQuery, ApiResponse<List<EntryDto>>>
{
    public async Task<ApiResponse<List<EntryDto>>> Handle(GetAllEntriesQuery request,
        CancellationToken cancellationToken)
    {
        var entries = await context.Entries
            .ToListAsync(cancellationToken);

        var entriesAsDto = mapper.Map<List<EntryDto>>(entries);
        return ApiResponse<List<EntryDto>>.SuccessResult(entriesAsDto);
    }
}

public static class GetAllEntriesEndpoint
{
    public static RouteGroupBuilder GetAllEntryGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("/",
                async (IMediator mediator) =>
                {
                    var result = await mediator.Send(new GetAllEntriesQuery());
                    return Results.Ok(result);
                }
            );

        return group;
    }
}
