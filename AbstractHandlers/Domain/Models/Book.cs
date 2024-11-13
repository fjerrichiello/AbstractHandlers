namespace AbstractHandlers.Structured.Domain.Models;

public record Book(int Id, int AuthorId, string Title)
{
    public Book(Persistence.Models.Book book) : this(book.Id, book.AuthorId, book.Title)
    {
    }
};