namespace MovieCharactersApi.Models.Requests;

public class CharactersInMovieUpdateRequestDto
{
    /// <summary>
    /// Ids of the characters to be set to the movie.
    /// </summary>
    public required IEnumerable<int> CharacterIds { get; set; }
}
