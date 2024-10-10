namespace FIAP.PhaseOne.Application.Handlers.Commands.DeleteContact;

public class DeleteContactRequest : IRequest<DeleteContactResponse>
{
    public Guid Id { get; set; }
}
