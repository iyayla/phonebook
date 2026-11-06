using AutoMapper;
using PhoneBook.Features.Entries.Dtos;

namespace PhoneBook.Features.Entries;

public class EntryMapping : Profile
{
    public EntryMapping()
    {
        CreateMap<Entry, EntryDto>().ReverseMap();
    }
}
