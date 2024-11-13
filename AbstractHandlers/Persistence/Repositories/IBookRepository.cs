using AbstractHandlers.Structured.Domain.Models;

namespace AbstractHandlers.Structured.Persistence.Repositories;

public interface IBookRepository
{
    Task<Book?> GetAsync(int id);

    Task AddAsync(Book book);
}