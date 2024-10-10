using FluentValidation;

namespace FIAP.PhaseOne.Application.Dto.Validators
{
    internal class PhoneDtoValidator: AbstractValidator<PhoneDto>
    {
        public PhoneDtoValidator()
        {
            RuleFor(x => x.DDD)
                .NotEmpty();

            RuleFor(x => x.Number)
                .NotEmpty()
                .MaximumLength(9);
        }
    }
}
