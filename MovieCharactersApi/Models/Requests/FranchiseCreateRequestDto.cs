using MovieCharactersApi.Data.Enums;

namespace MovieCharactersApi.Models.Requests;

public class FranchiseCreateRequestDto
{
    public required string Name { get; set; }

    public string? Description { get; set; }
}
