namespace MovieCharactersApi.Models.Responses;

public class FranchiseWithoutMoviesResponseDto
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }
}
