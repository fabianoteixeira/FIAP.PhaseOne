namespace FIAP.PhaseOne.Application.Handlers.Commands.DeleteContact;

public class DeleteContactRequest : IRequest
{
    public Guid Id { get; set; }
}
