using FIAP.PhaseOne.Application.Dto;
using FIAP.PhaseOne.Application.Handlers.Commands.UpdateContact.Dto;

namespace FIAP.PhaseOne.Application.Handlers.Commands.UpdateContact;

public class UpdateContactRequest : IRequest<UpdateContactResponse>
{
    public Guid Id { get; set; }
    public required ContactForUpdateDto Contact { get; set; }
}
