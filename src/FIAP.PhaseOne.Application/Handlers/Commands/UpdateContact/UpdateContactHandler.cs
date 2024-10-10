using AutoMapper;
using FIAP.PhaseOne.Application.Interfaces;

namespace FIAP.PhaseOne.Application.Handlers.Commands.UpdateContact;

public class UpdateContactHandler(
    IContactRepository contactRepository,
    IMapper mapper) : IRequestHandler<UpdateContactRequest, UpdateContactResponse>
{
    public async Task<UpdateContactResponse> Handle(
        UpdateContactRequest request,
        CancellationToken ct)
    {

        var contact = await contactRepository.GetById(request.Id, ct);

        if (contact is null)
        {
            Console.WriteLine("Contato não encontrado");
            //TODO: criar tratativa para badrequest

            return null;
        }

        contact.Update(
            request.Contact.Name, 
            request.Contact.Email, 
            mapper.Map<Domain.ContactAggregate.Phone>(request.Contact.Phone),
            mapper.Map<Domain.ContactAggregate.Address>(request.Contact.Address));

        await contactRepository.SaveChanges(ct);

        return new();
    }
}
