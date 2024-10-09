﻿using AutoMapper;
using FIAP.PhaseOne.Application.Interfaces;

namespace FIAP.PhaseOne.Application.Queries.GetContactById;

public class GetContactByIdHandler(
    IContactRepository contactRepository,
    IMapper mapper) : IRequestHandler<GetContactByIdRequestDto, GetContactByIdResponseDto>
{
    public async Task<GetContactByIdResponseDto> Handle(
        GetContactByIdRequestDto request, 
        CancellationToken ct)
    {
        var contact = await contactRepository.GetById(request.Id, ct);

        return new GetContactByIdResponseDto { Id = contact.Id };
    }
}
