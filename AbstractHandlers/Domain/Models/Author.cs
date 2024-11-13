namespace AbstractHandlers.Structured.Domain.Models;

public record Author(int Id, string FirstName, string LastName)
{
    public Author(Persistence.Models.Author entity) : this(entity.Id, entity.FirstName, entity.LastName)
    {
    }
};