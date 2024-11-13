using Common.Authorization;
using FluentValidation;

namespace AbstractHandlers.Structured.CommandHandlers.Authors.AddAuthor;

public class AddAuthorAuthorizer
    : Authorizer<AddAuthorData>
{
    public AddAuthorAuthorizer()
    {
        RuleFor(data => data.FirstName)
            .NotEmpty();
    }
}