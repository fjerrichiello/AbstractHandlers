using AbstractHandlers.Structured.Domain.Models;

namespace AbstractHandlers.Structured.Persistence.Repositories;

public interface IAuthorRepository
{
    Task<Author?> GetAsync(int id);

    Task<Author?> GetAsync(string firstName, string lastName);

    Task AddAsync(Author author);
}