using Common.Messaging;

namespace AbstractHandlers.Structured.Commands.Authors;

[FailedMessageTags("General", "Author", "Added")]
public record AddAuthorCommand(string FirstName, string LastName) : Message;