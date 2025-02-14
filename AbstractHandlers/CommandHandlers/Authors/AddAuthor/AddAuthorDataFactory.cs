﻿using AbstractHandlers.Structured.Commands.Authors;
using AbstractHandlers.Structured.Persistence.Repositories;
using Common.DataFactory;
using Common.Messaging;

namespace AbstractHandlers.Structured.CommandHandlers.Authors.AddAuthor;

public class AddAuthorDataFactory(IAuthorRepository _authorRepository)
    : IDataFactory<AddAuthorCommand, CommandMetadata, AddAuthorData>
{
    public async Task<AddAuthorData> GetDataAsync(MessageContainer<AddAuthorCommand, CommandMetadata> container)
    {
        var author = await _authorRepository.GetAsync(container.Message.FirstName, container.Message.LastName);

        return new AddAuthorData(author, container.Message.FirstName, container.Message.LastName);
    }
}