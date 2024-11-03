using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieCharactersApi.Data;
using MovieCharactersApi.Data.Entities;

namespace MovieCharactersApi.Services
{
    public class CharactersService : ICharactersService
    {
        private readonly DatabaseContext _context;

        public CharactersService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Character>> GetCharacters()
        {
            return await _context.Characters.ToListAsync();
        }

        public async Task<Character?> GetCharacter(int id)
        {
            return await _context.Characters.FindAsync(id);
        }

        public async Task<Character?> UpdateCharacter(Character character)
        {
            if (!await CharacterExists(character.Id))
            {
                return null;
            }

            _context.Entry(character).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return character;
        }

        public async Task<Character> CreateCharacter(Character character)
        {
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            return character;
        }

        public async Task<bool> DeleteCharacter(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                return false;
            }

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();

            return true;
        }

        private async Task<bool> CharacterExists(int id)
        {
            return await _context.Characters.AnyAsync(e => e.Id == id);
        }
    }
}
