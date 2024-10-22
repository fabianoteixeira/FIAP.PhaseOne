using AutoMapper;
using FIAP.PhaseOne.Application.Interfaces;
using FIAP.PhaseOne.Domain.ContactAggregate;

namespace FIAP.PhaseOne.Application.Handlers.Commands.AddContact;

public class AddContactHandler(
    IContactRepository contactRepository,
    IMapper mapper) : IRequestHandler<AddContactRequest, ValueResult<AddContactResponse>>
{
    public async Task<ValueResult<AddContactResponse>> Handle(
        AddContactRequest request,
        CancellationToken ct)
    {
        var contact = mapper.Map<Contact>(request);
        
        if (contact is null)
            return ValueResult<AddContactResponse>.Failure("não foi possível criar contato");

        await contactRepository.Add(contact, ct);

        return ValueResult<AddContactResponse>.Success( new() { Id = contact.Id });
    }
}
