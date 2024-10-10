using AutoMapper;
using FIAP.PhaseOne.Application.Interfaces;

namespace FIAP.PhaseOne.Application.Handlers.Commands.DeleteContact;

public class DeleteContactHandler(
    IContactRepository contactRepository,
    IMapper mapper) : IRequestHandler<DeleteContactRequest, DeleteContactResponse>
{
    public async Task<DeleteContactResponse> Handle(
        DeleteContactRequest request,
        CancellationToken ct)
    {

        await contactRepository.Remove(request.Id, ct);

        
        return new ();
    }
}
