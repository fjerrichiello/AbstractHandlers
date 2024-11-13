using Common.Validation;
using FluentValidation;

namespace AbstractHandlers.Structured.CommandHandlers.Authors.AddAuthor;

public class AddAuthorValidator
    : Validator<AddAuthorData>
{
    public AddAuthorValidator()
    {
        RuleFor(data => data.Author)
            .Null();

        RuleFor(data => data.FirstName)
            .NotEmpty();

        RuleFor(data => data.LastName)
            .NotEmpty();
    }
}