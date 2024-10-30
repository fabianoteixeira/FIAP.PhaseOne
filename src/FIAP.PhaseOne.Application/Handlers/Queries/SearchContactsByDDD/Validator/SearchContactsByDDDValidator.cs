using FluentValidation;

namespace FIAP.PhaseOne.Application.Handlers.Queries.SearchContactsByDDD.Validator;

internal class SearchContactsByDDDValidator : AbstractValidator<SearchContactsByDDDRequestDto>
{
    public SearchContactsByDDDValidator()
    {
        RuleFor(x => x.DDD)
            .NotEmpty()
            .GreaterThan(0)
            .LessThanOrEqualTo(99);
    }
}
