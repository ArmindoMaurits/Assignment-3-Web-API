namespace MovieCharactersApi.Models.Requests;

public class MovieUpdateRequestDto
{
    /// <summary>
    /// ID of the movie
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Title of the movie
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// Genre of a Movie (just a simple string of comma separated genres, 
    /// there is no genre modelling required as a base)
    /// </summary>
    public required string Genre { get; set; }

    /// <summary>
    /// Year of the release of the movie
    /// </summary>
    public int ReleaseYear { get; set; }

    /// <summary>
    /// Director (just a string name, no director modelling required as a base)
    /// </summary>
    public required string Director { get; set; }

    /// <summary>
    /// Picture URL (to a movie poster)
    /// </summary>
    public string? PictureUrl { get; set; }

    /// <summary>
    /// Trailer URL (YouTube link most likely)
    /// </summary>
    public string? TrailerUrl { get; set; }
}
