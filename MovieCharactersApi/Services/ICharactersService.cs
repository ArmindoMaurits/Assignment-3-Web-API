using MovieCharactersApi.Data.Entities;

namespace MovieCharactersApi.Services
{
    public interface ICharactersService
    {
        Task<Character> CreateCharacter(Character character);
        Task<bool> DeleteCharacter(int id);
        Task<Character?> GetCharacter(int id);
        Task<IEnumerable<Character>> GetCharacters();
        Task<Character?> UpdateCharacter(Character character);
    }
}