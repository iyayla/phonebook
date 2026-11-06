using PhoneBook.Features.Entries.Create;
using PhoneBook.Features.Entries.Delete;
using PhoneBook.Features.Entries.GetAll;
using PhoneBook.Features.Entries.GetById;
using PhoneBook.Features.Entries.Update;

namespace PhoneBook.Features.Entries;

public static class EntryEndpointExt
{
    public static void AddEntryGroupEndpointExt(this WebApplication app)
    {
        app.MapGroup("api/entries")
            .CreateEntryGroupItemEndpoint()
            .DeleteEntryGroupItemEndpoint()
            .GetAllEntryGroupItemEndpoint()
            .GetByIdEntryGroupItemEndpoint()
            .UpdateEntryGroupItemEndpoint()
            ;
    }
}
