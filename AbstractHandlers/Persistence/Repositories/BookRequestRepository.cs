using AbstractHandlers.Structured.Domain.Models;
using AbstractHandlers.Structured.Persistence.Models;
using Common.Enums;
using Microsoft.EntityFrameworkCore;

namespace AbstractHandlers.Structured.Persistence.Repositories;

public class BookRequestRepository(ApplicationDbContext _context) : IBookRequestRepository
{
    public async Task AddAddBookRequestAsync(AddBookRequest addBookRequest)
        => await _context.BookRequests.AddAsync(new BookRequest(addBookRequest));

    public async Task AddEditBookRequestAsync(EditBookRequest editBookRequest)
        => await _context.BookRequests.AddAsync(new BookRequest(editBookRequest));

    public async Task<List<AddBookRequest>> GetAddRequests(int authorId, string title)
    {
        var entities = await _context.BookRequests
            .Where(x => x.AuthorId == authorId && x.Title.ToLower() == title.ToLower() &&
                        x.RequestType == RequestType.Add).ToListAsync();

        return entities.Select(e => new AddBookRequest(e)).ToList();
    }

    public async Task<List<EditBookRequest>> GetEditRequests(int authorId, string title)
    {
        var entities = await _context.BookRequests
            .Where(x => x.AuthorId == authorId && x.Title.ToLower() == title.ToLower() &&
                        x.RequestType == RequestType.Edit).ToListAsync();

        return entities.Select(e => new EditBookRequest(e)).ToList();
    }
}