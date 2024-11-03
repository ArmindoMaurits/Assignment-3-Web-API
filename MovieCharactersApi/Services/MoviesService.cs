
using Microsoft.EntityFrameworkCore;
using MovieCharactersApi.Data;
using MovieCharactersApi.Data.Entities;

namespace MovieCharactersApi.Services;

public class MoviesService
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

        _context.Movies.Remove(movie);
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