using MovieCharactersApi.Data.Enums;

namespace MovieCharactersApi.Models.Requests;

public class FranchiseUpdateRequest
{
    public required int Id { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }
}
