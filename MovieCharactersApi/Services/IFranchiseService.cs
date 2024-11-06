using MovieCharactersApi.Data.Entities;

namespace MovieCharactersApi.Services
{
    public interface IFranchiseService
    {
        Task<Franchise> CreateFranchise(Franchise franchise);
        Task<bool> DeleteFranchise(int id);
        Task<Franchise?> GetFranchise(int id);
        Task<IEnumerable<Franchise>> GetFranchises();
        Task<Franchise?> UpdateFranchise(Franchise franchise);
    }
}