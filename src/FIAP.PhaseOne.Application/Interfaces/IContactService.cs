using FIAP.PhaseOne.Application.Dto;

namespace FIAP.PhaseOne.Application.Interfaces
{
    public interface IContactService
    {
        Task AddContact(ContactDto contactDto, CancellationToken ct);
        Task<ContactDto> GetContactById(Guid id, CancellationToken ct);
        Task UpdateContact(ContactDto contactDto, CancellationToken ct);
        Task RemoveContact(Guid id, CancellationToken ct);
        Task<IEnumerable<ContactDto>> GetAllContacts(int page, int limit, CancellationToken ct);
    }
}
