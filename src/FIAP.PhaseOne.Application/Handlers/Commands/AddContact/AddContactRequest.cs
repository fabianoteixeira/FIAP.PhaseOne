using FIAP.PhaseOne.Application.Dto;

namespace FIAP.PhaseOne.Application.Handlers.Commands.AddContact;

public class AddContactRequest : IRequest<AddContactResponse>
{
    public required ContactDto Contact { get; set; }
}
