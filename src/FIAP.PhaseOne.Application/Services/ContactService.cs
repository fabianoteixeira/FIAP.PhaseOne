using AutoMapper;
using FIAP.PhaseOne.Application.Dto;
using FIAP.PhaseOne.Application.Interfaces;
using FIAP.PhaseOne.Domain.ContactAggregate;

namespace FIAP.PhaseOne.Application.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public ContactService(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task AddContact(ContactDto contactDto, CancellationToken ct)
        {
            var contact = _mapper.Map<Contact>(contactDto);
            await _contactRepository.Add(contact, ct);
        }

        public async Task<ContactDto> GetContactById(Guid id, CancellationToken ct)
        {
            var contact = await _contactRepository.GetById(id, ct);
            return _mapper.Map<ContactDto>(contact);
        }

        public async Task UpdateContact(ContactDto contactDto, CancellationToken ct)
        {
            var contact = _mapper.Map<Contact>(contactDto);
            await _contactRepository.Update(contact, ct);
        }

        public async Task RemoveContact(Guid id, CancellationToken ct)
        {
            await _contactRepository.Remove(id, ct);
        }

        public async Task<IEnumerable<ContactDto>> GetAllContacts(
            int page, 
            int limit, 
            CancellationToken ct)
        {
            var contacts = await _contactRepository.GetAll(page, limit, ct);

            return contacts.Select(_mapper.Map<ContactDto>);
        }
    }
}
