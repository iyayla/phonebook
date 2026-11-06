using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Features.Entries.Dtos;
using PhoneBook.Repositories;
using PhoneBook.Shared;

namespace PhoneBook.Features.Entries.GetById;

public record GetCourseByIdQuery(Guid Id) : IRequest<ApiResponse<EntryDto>>;

public class GetEntryByIdQueryHandler(AppDbContext context, IMapper mapper)
    : IRequestHandler<GetCourseByIdQuery, ApiResponse<EntryDto>>
{
    public async Task<ApiResponse<EntryDto>> Handle(GetCourseByIdQuery request,
        CancellationToken cancellationToken)
    {
        var entry = await context.Entries.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (entry is null)
            return ApiResponse<EntryDto>.ErrorResult("Item was not found");

        var entryAsDto = mapper.Map<EntryDto>(entry);
        return ApiResponse<EntryDto>.SuccessResult(entryAsDto);
    }
}

public static class GetEntryByIdEndpoint
{
    public static RouteGroupBuilder GetByIdEntryGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("/{id:guid}",
                async (IMediator mediator, Guid id) =>
                {
                    var result = await mediator.Send(new GetCourseByIdQuery(id));
                    return Results.Ok(result);
                });

        return group;
    }
}
