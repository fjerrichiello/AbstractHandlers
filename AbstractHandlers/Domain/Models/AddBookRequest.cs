using AbstractHandlers.Structured.Persistence.Models;

namespace AbstractHandlers.Structured.Domain.Models;

public record AddBookRequest(int AuthorId, string Title)
{
    public AddBookRequest(BookRequest bookRequest) : this(bookRequest.AuthorId, bookRequest.Title)
    {
    }
};