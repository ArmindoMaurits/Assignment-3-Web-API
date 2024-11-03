using MovieCharactersApi.Data.Entities;

namespace MovieCharactersApi.Services
{
    public interface IMoviesService
    {
        Task<Movie?> CreateMovie(Movie movie);
        Task<bool> DeleteMovie(int id);
        Task<Movie?> GetMovie(int id);
        Task<IEnumerable<Movie>> GetMovies();
        Task<bool> UpdateCharactersInMovie(int id, IEnumerable<int> characterIds);
        Task<Movie?> UpdateMovie(Movie movie);
    }
}