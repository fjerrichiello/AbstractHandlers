using AbstractHandlers.Structured.Commands.Authors;
using AbstractHandlers.Structured.Domain.Models;
using AbstractHandlers.Structured.Persistence.Repositories;
using AbstractHandlers.Structured.Persistence.UnitOfWork;
using Common.Events.AddAuthorCommand;
using Common.Authorization;
using Common.DataFactory;
using Common.Messaging;
using Common.StructuredHandlers;
using FluentValidation;

namespace AbstractHandlers.Structured.CommandHandlers.Authors.AddAuthor;

public class AddAuthorCommandHandler(
    IDataFactory<AddAuthorCommand, CommandMetadata, AddAuthorData> _dataFactory,
    IAuthorizer<AddAuthorData> _authorizer,
    IValidator<AddAuthorData> _validator,
    IEventPublisher _eventPublisher,
    ILogger<AddAuthorCommandHandler> _logger,
    IAuthorRepository _authorRepository,
    IUnitOfWork _unitOfWork)
    : AuthorizedCommandHandler<AddAuthorCommand, AddAuthorData>(_dataFactory, _authorizer, _validator, _eventPublisher,
        _logger)
{
    public override async Task Process(MessageContainer<AddAuthorCommand, CommandMetadata> commandContainer,
        AddAuthorData data)
    {
        var author = new Author(Random.Shared.Next(1000000), data.FirstName, data.LastName);

        await _authorRepository.AddAsync(author);

        await _unitOfWork.CompleteAsync();

        await _eventPublisher.PublishAsync(commandContainer,
            new AuthorAddedEvent(author.Id, author.FirstName, author.LastName));
    }
}