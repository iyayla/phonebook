using MongoDB.Bson.Serialization.Attributes;

namespace PhoneBook.Repositories;

public class BaseEntity
{
    [BsonElement("_id")]
    public Guid Id { get; set; }
}
