using FluentValidation;

namespace FIAP.PhaseOne.Application.Dto.Validators
{
    internal class PhoneDtoValidator: AbstractValidator<PhoneDto>
    {
        public PhoneDtoValidator()
        {
            RuleFor(x => x.DDD)
                .NotEmpty()
                .GreaterThan(0)
                .LessThan(99);

            RuleFor(x => x.Number)
                .NotEmpty()
                .MaximumLength(9)
                .Matches("^[0-9]+$").WithMessage("Informar somente números (sem caracteres especiais)");
        }
    }
}
