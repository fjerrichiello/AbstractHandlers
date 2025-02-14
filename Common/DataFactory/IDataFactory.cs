﻿using Common.Messaging;

namespace Common.DataFactory;

public interface IDataFactory<TMessage, TMessageMetadata, TData>
    where TMessage : Message
    where TMessageMetadata : MessageMetadata
{
    Task<TData> GetDataAsync(MessageContainer<TMessage, TMessageMetadata> container);
}