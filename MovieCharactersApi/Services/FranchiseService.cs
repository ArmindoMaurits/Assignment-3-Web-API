using Microsoft.EntityFrameworkCore;
using MovieCharactersApi.Data;
using MovieCharactersApi.Data.Entities;

namespace MovieCharactersApi.Services;

public class FranchiseService : IFranchiseService
{
    private readonly DatabaseContext _context;

    public FranchiseService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Franchise>> GetFranchises()
    {
        return await _context
            .Franchises
            .ToListAsync();
    }

    public async Task<Franchise?> GetFranchise(int id)
    {
        return await _context
            .Franchises
            .FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<IEnumerable<Movie>> GetMoviesInFranchise(int franchiseId)
    {
        return await _context
            .Movies
            .Where(m => m.FranchiseId == franchiseId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Character>> GetCharactersInFranchise(int franchiseId)
    {
        return await _context
            .Characters
            .Where(c => c.Movies.Any(m => m.FranchiseId == franchiseId))
            .ToListAsync();
    }

    public async Task<Franchise?> UpdateFranchise(Franchise franchise)
    {
        if (!await FranchiseExists(franchise.Id))
        {
            return null;
        }

        _context.Entry(franchise).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return franchise;
    }

    public async Task<Franchise> CreateFranchise(Franchise franchise)
    {
        _context.Franchises.Add(franchise);
        await _context.SaveChangesAsync();

        return franchise;
    }

    public async Task<bool> DeleteFranchise(int id)
    {
        var franchise = await _context.Franchises.FindAsync(id);
        if (franchise == null)
        {
            return false;
        }

        _context.Franchises.Remove(franchise);
        await _context.SaveChangesAsync();

        return true;
    }

    private async Task<bool> FranchiseExists(int id)
    {
        return await _context.Franchises.AnyAsync(e => e.Id == id);
    }

    public async Task<bool> UpdateMoviesInFranchise(int id, IEnumerable<int> movieIds)
    {
        var franchise = await _context.Franchises
            .Include(f => f.Movies)
            .FirstOrDefaultAsync(f => f.Id == id);

        if (franchise == null)
        {
            return false;
        }

        franchise.Movies.Clear();
        franchise.Movies = await _context.Movies
            .Where(m => movieIds.Contains(m.Id))
            .ToListAsync();

        await _context.SaveChangesAsync();

        return true;
    }
}