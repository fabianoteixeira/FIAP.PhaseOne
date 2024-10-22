using FIAP.PhaseOne.Application.Handlers.Queries.SearchContactsByDDD;
using FluentValidation;

namespace FIAP.PhaseOne.Application.Handlers.Commands.SearchContactsByDDD;

internal class SearchContactsByDDDValidator : AbstractValidator<SearchContactsByDDDRequestDto>
{
    public SearchContactsByDDDValidator()
    {
        RuleFor(x => x.DDD)
            .NotEmpty()
            .GreaterThan(0)
            .LessThan(90);
    }
}
