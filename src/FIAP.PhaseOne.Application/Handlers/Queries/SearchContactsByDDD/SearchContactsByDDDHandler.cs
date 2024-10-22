using AutoMapper;
using FIAP.PhaseOne.Application.Dto;
using FIAP.PhaseOne.Application.Interfaces;

namespace FIAP.PhaseOne.Application.Handlers.Queries.SearchContactsByDDD;

public class SearchContactsByDDDHandler(
    IContactRepository contactRepository,
    IMapper mapper) : IRequestHandler<SearchContactsByDDDRequestDto, SearchContactsByDDDResponseDto?>
{
    public async Task<SearchContactsByDDDResponseDto?> Handle(
        SearchContactsByDDDRequestDto request,
        CancellationToken ct)
    {
        var (contactsPaged, total) = await contactRepository.GetAll(
            request.Page, request.Limit, ct, ddd: request.DDD);

        var contacts = contactsPaged.Select(mapper.Map<ContactWithIdDto>);

        var response = new PaginationDto<ContactWithIdDto>(contacts, total, request.Page, request.Limit);

        return new SearchContactsByDDDResponseDto { Contacts = response };
    }
}
