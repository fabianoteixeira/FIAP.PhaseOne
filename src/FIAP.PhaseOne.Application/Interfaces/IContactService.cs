using FIAP.PhaseOne.Application.Dto;

namespace FIAP.PhaseOne.Application.Interfaces
{
    public interface IContactService
    {
        Task AddContact(ContactRequestDto contactDto);
        ContactRequestDto GetContactById(Guid id);
        Task UpdateContact(ContactRequestDto contactDto);
        Task RemoveContact(Guid id);
    }
}
