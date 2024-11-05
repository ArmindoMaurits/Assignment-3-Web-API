using MovieCharactersApi.Data.Entities;

namespace MovieCharactersApi.Services
{
    public interface ICharactersService
    {
        /// <summary>
        /// Creates a character
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        Task<Character> CreateCharacter(Character character);

        /// <summary>
        /// Deleted a character
        /// </summary>
        /// <param name="id">ID of the character</param>
        /// <returns>True if deleted, false otherwise</returns>
        Task<bool> DeleteCharacter(int id);

        /// <summary>
        /// Gets a character by given ID
        /// </summary>
        /// <param name="id">ID of the character</param>
        /// <returns>Character if found, null otherwise.</returns>
        Task<Character?> GetCharacter(int id);

        /// <summary>
        /// Gets all characters from the database.
        /// </summary>
        /// <returns>List of characters</returns>
        Task<IEnumerable<Character>> GetCharacters();

        /// <summary>
        /// Updates a given character
        /// </summary>
        /// <param name="character"></param>
        /// <returns>Character if updated, null otherwise</returns>
        Task<Character?> UpdateCharacter(Character character);
    }
}