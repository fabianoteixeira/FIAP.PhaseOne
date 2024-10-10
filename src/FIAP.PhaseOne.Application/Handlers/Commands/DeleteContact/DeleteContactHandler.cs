using AutoMapper;
using FIAP.PhaseOne.Application.Interfaces;

namespace FIAP.PhaseOne.Application.Handlers.Commands.DeleteContact;

public class DeleteContactHandler(
    IContactRepository contactRepository,
    IMapper mapper) : IRequestHandler<DeleteContactRequest>
{
    public async Task Handle(
        DeleteContactRequest request,
        CancellationToken ct)
    {
        await contactRepository.Remove(request.Id, ct);
    }
}
