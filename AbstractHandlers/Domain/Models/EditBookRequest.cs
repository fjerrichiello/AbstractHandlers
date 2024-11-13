using AbstractHandlers.Structured.Persistence.Models;

namespace AbstractHandlers.Structured.Domain.Models;

public record EditBookRequest(int AuthorId, string Title, string NewTitle)
{
    public EditBookRequest(BookRequest bookRequest) : this(bookRequest.AuthorId, bookRequest.Title,
        bookRequest.NewTitle)
    {
    }
};