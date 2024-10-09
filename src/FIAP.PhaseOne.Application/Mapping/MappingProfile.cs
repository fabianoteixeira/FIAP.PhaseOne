﻿using AutoMapper;
using FIAP.PhaseOne.Application.Commands.AddContact;
using FIAP.PhaseOne.Domain.ContactAggregate;

namespace FIAP.PhaseOne.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddContactRequest, Contact>().ReverseMap();
            //CreateMap<Address, AddressDto>().ReverseMap();
            //CreateMap<Phone, PhoneDto>().ReverseMap();
        }
    }
}
