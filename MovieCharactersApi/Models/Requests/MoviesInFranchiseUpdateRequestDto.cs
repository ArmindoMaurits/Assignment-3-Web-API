namespace MovieCharactersApi.Models.Requests;

public class MoviesInFranchiseUpdateRequestDto
{
    /// <summary>
    /// Ids of the movies to be set to the franchise.
    /// </summary>
    public required IEnumerable<int> MovieIds { get; set; }
}
