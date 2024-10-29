using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieCharactersApi.Data;
using MovieCharactersApi.Data.Entities;

namespace MovieCharactersApi.Services
{
    public class CharactersService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public CharactersService(DatabaseContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Character>> GetCharacters()
        {
            return await _context.Characters.ToListAsync();
        }

        public async Task<Character?> GetCharacter(int id)
        {
            return await _context.Characters.FindAsync(id);
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

        private bool CharacterExists(int id)
        {
            return _context.Characters.Any(e => e.Id == id);
        }
    }
}
