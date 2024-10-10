using FluentValidation;

namespace FIAP.PhaseOne.Application.Dto.Validators
{
    internal class AddressDtoValidator: AbstractValidator<AddressDto>
    {
        public AddressDtoValidator()
        {
            RuleFor(x => x.Street)
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(x => x.Number)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.District)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.City)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Country)
                .NotEmpty()
                .MaximumLength(2);

            RuleFor(x => x.Zipcode)
                .NotEmpty()
                .MaximumLength(8);
        }
    }
}
