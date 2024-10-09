using AutoMapper;
using FIAP.PhaseOne.Api.Dto;
using FIAP.PhaseOne.Application.Commands.AddContact;
using FIAP.PhaseOne.Domain.ContactAggregate;

namespace FIAP.PhaseOne.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ContactDto, AddContactRequest>().ReverseMap();
            //CreateMap<Address, AddressDto>().ReverseMap();
            //CreateMap<Phone, PhoneDto>().ReverseMap();
        }
    }
}
