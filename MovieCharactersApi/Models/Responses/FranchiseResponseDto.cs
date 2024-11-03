namespace MovieCharactersApi.Models.Responses;

public class FranchiseResponseDto
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    public IEnumerable<MovieResponseDto> Movies { get; set; } = new List<MovieResponseDto>();
}
