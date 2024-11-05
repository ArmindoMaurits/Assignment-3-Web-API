using MovieCharactersApi.Data.Entities;

namespace MovieCharactersApi.Services
{
    public interface IMoviesService
    {
        /// <summary>
        /// Creates a new movie if the franchise exists.
        /// </summary>
        /// <param name="movie">Movie to be created.</param>
        /// <returns>Movie if created,</returns>
        Task<Movie?> CreateMovie(Movie movie);

        /// <summary>
        /// Deletes a movie
        /// </summary>
        /// <param name="id">ID of the movie</param>
        /// <returns>true if deleted, false otherwise</returns>
        Task<bool> DeleteMovie(int id);

        /// <summary>
        /// Gets a movie by given ID
        /// </summary>
        /// <param name="id">ID of the movie</param>
        /// <returns>Movie if found, null otherwise</returns>
        Task<Movie?> GetMovie(int id);

        /// <summary>
        /// Gets all movies from the database
        /// </summary>
        /// <returns>List of movies</returns>
        Task<IEnumerable<Movie>> GetMovies();

        /// <summary>
        /// Updates the characters in a given movie
        /// </summary>
        /// <param name="id">Movie ID</param>
        /// <param name="characterIds">List of character IDs</param>
        /// <returns></returns>
        Task<bool> UpdateCharactersInMovie(int id, IEnumerable<int> characterIds);

        /// <summary>
        /// Updated a given movie   
        /// </summary>
        /// <param name="movie">Movie to be updated.</param>
        /// <returns>Movie that was updated or null if it was not found.</returns>
        Task<Movie?> UpdateMovie(Movie movie);
    }
}