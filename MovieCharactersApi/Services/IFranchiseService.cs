using MovieCharactersApi.Data.Entities;

namespace MovieCharactersApi.Services
{
    public interface IFranchiseService
    {
        /// <summary>
        /// Create a new franchise
        /// </summary>
        /// <param name="franchise">Franchise to be created</param>
        /// <returns>Franchise that was created</returns>
        Task<Franchise> CreateFranchise(Franchise franchise);

        /// <summary>
        /// Delete a franchise
        /// </summary>
        /// <param name="id">ID of the franchise that has to be deleted</param>
        /// <returns>True if deleted, false otherwise</returns>
        Task<bool> DeleteFranchise(int id);

        /// <summary>
        /// Gets a franchise by ID
        /// </summary>
        /// <param name="id">ID of the franchise</param>
        /// <returns>Franchise if found, null otherwise</returns>
        Task<Franchise?> GetFranchise(int id);

        /// <summary>
        /// Gets all franchises
        /// </summary>
        /// <returns>List of franchises</returns>
        Task<IEnumerable<Franchise>> GetFranchises();

        /// <summary>
        /// Update a franchise
        /// </summary>
        /// <param name="franchise">Franchise to be updated</param>
        /// <returns>Franchise that was updated, null if not found</returns>
        Task<Franchise?> UpdateFranchise(Franchise franchise);

        /// <summary>
        /// Get all movies in a franchise
        /// </summary>
        /// <param name="franchiseId">ID of the franchise</param>
        /// <returns>List of movies in that given franchise</returns>
        Task<IEnumerable<Movie>> GetMoviesInFranchise(int franchiseId);

        /// <summary>
        /// Get all characters in a franchise
        /// </summary>
        /// <param name="franchiseId">ID of the franchise</param>
        /// <returns>List of characters in that given franchise</returns>
        Task<IEnumerable<Character>> GetCharactersInFranchise(int franchiseId);

        /// <summary>
        /// Update movies in a franchise
        /// </summary>
        /// <param name="id">ID of the franchise</param>
        /// <param name="movieIds">IDs of the movie</param>
        /// <returns>True if updated, false otherwise.</returns>
        Task<bool> UpdateMoviesInFranchise(int id, IEnumerable<int> movieIds);
    }
}