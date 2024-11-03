using Microsoft.EntityFrameworkCore;
using MovieCharactersApi.Data;
using MovieCharactersApi.Data.Entities;

namespace MovieCharactersApi.Services;

public class MoviesService : IMoviesService
{
    private readonly DatabaseContext _context;

    public MoviesService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Movie>> GetMovies()
    {
        return await _context.Movies
            .Include(m => m.Franchise)
            .Include(m => m.Characters)
            .ToListAsync();
    }

    public async Task<Movie?> GetMovie(int id)
    {
        return await _context.Movies
            .Include(m => m.Franchise)
            .Include(m => m.Characters)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Movie?> UpdateMovie(Movie movie)
    {
        if (!await MovieExists(movie.Id))
        {
            return null;
        }

        _context.Entry(movie).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return movie;
    }

    public async Task<Movie?> CreateMovie(Movie movie)
    {
        if (!await FranchiseExists(movie.FranchiseId.GetValueOrDefault()))
        {
            return null;
        }

        _context.Movies.Add(movie);
        await _context.SaveChangesAsync();

        return movie;
    }

    /// <summary>
    /// Deletes a movie from the database, if it exists otherwise returns false.
    /// </summary>
    /// <param name="id">ID of the movie</param>
    /// <returns>True if deleted, false if not found.</returns>
    public async Task<bool> DeleteMovie(int id)
    {
        var movie = await _context.Movies.FindAsync(id);
        if (movie == null)
        {
            return false;
        }

        movie.Franchise = null;
        movie.Characters.Clear();
        await _context.SaveChangesAsync();

        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// Sets the characters in a movie to the given character IDs.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="characterIds"></param>
    /// <returns>True if set, false if no movie was found by given ID.</returns>
    public async Task<bool> UpdateCharactersInMovie(int id,
        IEnumerable<int> characterIds)
    {
        if (!await MovieExists(id))
        {
            return false;
        }

        var movie = await _context.Movies
            .Include(m => m.Characters)
            .FirstAsync(m => m.Id == id);

        movie.Characters.Clear();
        foreach (var characterId in characterIds)
        {
            var character = await _context.Characters.FindAsync(characterId);
            if (character != null)
            {
                movie.Characters.Add(character);
            }
        }

        await _context.SaveChangesAsync();

        return true;
    }

    private async Task<bool> MovieExists(int id)
    {
        return await _context.Movies.AnyAsync(e => e.Id == id);
    }

    private async Task<bool> FranchiseExists(int id)
    {
        return await _context.Franchises.AnyAsync(e => e.Id == id);
    }

}