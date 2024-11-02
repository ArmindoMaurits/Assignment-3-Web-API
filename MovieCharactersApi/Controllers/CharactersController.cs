using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieCharactersApi.Data.Entities;
using MovieCharactersApi.Models.Requests;
using MovieCharactersApi.Models.Responses;
using MovieCharactersApi.Services;

namespace MovieCharactersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly CharactersService _charactersService;
        private readonly IMapper _mapper;

        public CharactersController(
            CharactersService charactersService,
            IMapper mapper)
        {
            _charactersService = charactersService;
            _mapper = mapper;
        }

        // GET: api/Characters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterResponseDto>>> GetCharacters()
        {
            var characters = await _charactersService.GetCharacters();
            var characterResponseDtos = _mapper.Map<IEnumerable<CharacterResponseDto>>(characters);

            return characterResponseDtos.ToList();
        }

        // GET: api/Characters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterResponseDto>> GetCharacter(int id)
        {
            var character = await _charactersService.GetCharacter(id);
            if (character == null)
            {
                return NotFound();
            }

            return _mapper.Map<CharacterResponseDto>(character);
        }

        // PUT: api/Characters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(
            int id, CharacterResponseDto characterToBeUpdated)
        {
            if (id != characterToBeUpdated.Id)
            {
                return BadRequest();
            }

            var character = _mapper.Map<Character>(characterToBeUpdated);
            var updatedCharacter = await _charactersService.UpdateCharacter(character);
            if (updatedCharacter == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Characters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(
            CharacterCreateRequestDto characterCreateRequestDto)
        {
            var character = _mapper.Map<Character>(characterCreateRequestDto);
            var createdCharacter = await _charactersService.CreateCharacter(character);

            return CreatedAtAction("GetCharacter", 
                new { id = createdCharacter.Id }, 
                createdCharacter);
        }

        // DELETE: api/Characters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            var deleted = await _charactersService.DeleteCharacter(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
