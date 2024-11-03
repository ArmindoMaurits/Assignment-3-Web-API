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
        private readonly ICharactersService _charactersService;
        private readonly IMapper _mapper;

        public CharactersController(
            ICharactersService charactersService,
            IMapper mapper)
        {
            _charactersService = charactersService;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all characters.
        /// </summary>
        /// <returns>List of CharacterResponseDtos</returns>
        // GET: api/Characters
        [ProducesResponseType(typeof(IEnumerable<CharacterResponseDto>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterResponseDto>>> GetCharacters()
        {
            var characters = await _charactersService.GetCharacters();
            var characterResponseDtos = _mapper.Map<IEnumerable<CharacterResponseDto>>(characters);

            return characterResponseDtos.ToList();
        }

        /// <summary>
        /// Gets a character by id.
        /// </summary>
        /// <param name="id">ID of the Character</param>
        /// <returns>CharacterResponseDto if found, otherwise 404.</returns>
        // GET: api/Characters/5
        [ProducesResponseType(typeof(CharacterResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        /// <summary>
        /// Updates a character by id.
        /// </summary>
        /// <param name="id">ID of the character</param>
        /// <param name="characterToBeUpdated">Character to be updated</param>
        /// <returns>204 if updated, 404 if not found or 400 if ID wasn't correct.</returns>
        // PUT: api/Characters/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        /// <summary>
        /// Creates a new character.
        /// </summary>
        /// <param name="characterCreateRequestDto">The character to be created</param>
        /// <returns>The newly created Character.</returns>
        // POST: api/Characters
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<ActionResult<CharacterResponseDto>> PostCharacter(
            CharacterCreateRequestDto characterCreateRequestDto)
        {
            var character = _mapper.Map<Character>(characterCreateRequestDto);
            var createdCharacter = await _charactersService.CreateCharacter(character);
            var characterResponseDto = _mapper.Map<CharacterResponseDto>(createdCharacter);

            return CreatedAtAction("GetCharacter", 
                new { id = characterResponseDto.Id },
                characterResponseDto);
        }

        /// <summary>
        /// Deletes a character by id.
        /// </summary>
        /// <param name="id">ID of the character</param>
        /// <returns>204 if deleted, 404 if character wasn't found by given ID</returns>
        // DELETE: api/Characters/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
