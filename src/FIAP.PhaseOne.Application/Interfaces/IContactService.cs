using FIAP.PhaseOne.Application.Dto;
using FIAP.PhaseOne.Application.Handlers.Commands.UpdateContact.Dto;

namespace FIAP.PhaseOne.Application.Interfaces
{
    public interface IContactService
    {
        Task AddContact(ContactDto contactDto, CancellationToken ct);
        Task<ContactDto> GetContactById(Guid id, CancellationToken ct);
        Task UpdateContact(ContactDto contactDto, CancellationToken ct);
        Task RemoveContact(Guid id, CancellationToken ct);
        Task<PaginationDto<ContactDto>> GetAllContacts(int page, int limit, CancellationToken ct);
    }
}
