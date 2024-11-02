using FIAP.PhaseOne.Application.Dto.Validators;
using FluentValidation;

namespace FIAP.PhaseOne.Application.Handlers.Commands.UpdateContact.Validator;

public class UpdateContactValidator : AbstractValidator<UpdateContactRequest>
{
    public UpdateContactValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.Contact)
            .NotEmpty();

        When(x => x.Contact is not null, () =>
        {

            RuleFor(x => x.Contact.Name)
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(x => x.Contact.Name)
               .Matches("^[A-Za-záéíóúàèìòùâêîôûãõçñ]+(?: [A-Za-záéíóúàèìòùâêîôûãõçñ]+)+$")
               .WithMessage("Invalid name");

            RuleFor(x => x.Contact.Email)
                .NotEmpty()
                .MaximumLength(100)
                .EmailAddress();

            RuleFor(x => x.Contact.Address)
                .NotEmpty();

            RuleFor(x => x.Contact.Phone)
               .NotEmpty();

            RuleFor(x => x.Contact.Address).SetValidator(new AddressDtoValidator());

            RuleFor(x => x.Contact.Phone).SetValidator(new PhoneDtoValidator());
        });
    }
}
