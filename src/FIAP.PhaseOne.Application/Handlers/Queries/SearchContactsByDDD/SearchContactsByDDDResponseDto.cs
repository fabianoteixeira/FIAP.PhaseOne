using FIAP.PhaseOne.Application.Dto;

namespace FIAP.PhaseOne.Application.Handlers.Queries.SearchContactsByDDD;

public class SearchContactsByDDDResponseDto
{
    public required PaginationDto<ContactWithIdDto> Contacts { get; set; }
}
