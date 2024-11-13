using AbstractHandlers.Structured.Domain.Models;

namespace AbstractHandlers.Structured.CommandHandlers.Authors.AddAuthor;

public record AddAuthorData(Author? Author, string FirstName, string LastName);