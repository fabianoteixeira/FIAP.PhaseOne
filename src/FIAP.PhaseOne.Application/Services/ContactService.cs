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

        public async Task AddContact(ContactRequestDto contactDto)
        {
            var contact = _mapper.Map<Contact>(contactDto);
            _contactRepository.Add(contact);
        }

        public ContactRequestDto GetContactById(Guid id)
        {
            var contact = _contactRepository.GetById(id);
            return _mapper.Map<ContactRequestDto>(contact);
        }

        public async Task UpdateContact(ContactRequestDto contactDto)
        {
            var contact = _mapper.Map<Contact>(contactDto);
            _contactRepository.Update(contact);
        }

        public async Task RemoveContact(Guid id)
        {
            _contactRepository.Remove(id);
        }
    }
}
