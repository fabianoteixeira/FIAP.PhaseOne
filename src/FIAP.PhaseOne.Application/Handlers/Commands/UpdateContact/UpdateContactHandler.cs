using FIAP.PhaseOne.Application.Interfaces;

namespace FIAP.PhaseOne.Application.Handlers.Commands.UpdateContact;

public class UpdateContactHandler(IContactRepository contactRepository) : IRequestHandler<UpdateContactRequest>
{
    public async Task Handle(
        UpdateContactRequest request,
        CancellationToken ct)
    {
        var contact = await contactRepository.GetById(request.Id, ct);

        //TODO: criar tratativa para badrequest
        if (contact is null) return;

        contact.Update(request.Contact.Name, request.Contact.Email);

        contact.UpdatePhone(request.Contact.Phone.DDD, request.Contact.Phone.Number);

        var newAddress = request.Contact.Address;
        contact.UpdateAddress(
            newAddress.Street, 
            newAddress.Number, 
            newAddress.City, 
            newAddress.District, 
            newAddress.Country, 
            newAddress.Zipcode, 
            newAddress.Complement);

        await contactRepository.SaveChanges(ct);
    }
}
