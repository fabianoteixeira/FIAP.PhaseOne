using AutoMapper;
using FIAP.PhaseOne.Application.Interfaces;
using FIAP.PhaseOne.Domain.ContactAggregate;

namespace FIAP.PhaseOne.Application.Handlers.Commands.AddContact;

public class AddContactHandler(
    IContactRepository contactRepository,
    IMapper mapper) : IRequestHandler<AddContactRequest, AddContactResponse>
{
    public async Task<AddContactResponse> Handle(
        AddContactRequest request,
        CancellationToken ct)
    {
        var contact = mapper.Map<Contact>(request.Contact);

        await contactRepository.Add(contact, ct);

        return new AddContactResponse { Id = contact.Id };
    }
}
