namespace FIAP.PhaseOne.Application.Handlers.Queries.SearchContactsByDDD;

public class SearchContactsByDDDRequestDto : IRequest<SearchContactsByDDDResponseDto>
{
    public required int DDD { get; init; }
    public int Page { get; init; }
    public int Limit { get; init; }
}
