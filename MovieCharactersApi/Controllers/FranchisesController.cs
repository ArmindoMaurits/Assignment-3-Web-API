using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieCharactersApi.Data.Entities;
using MovieCharactersApi.Models.Responses;
using MovieCharactersApi.Services;

namespace MovieCharactersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FranchisesController : ControllerBase
    {
        private readonly IFranchiseService _franchiseService;
        private readonly IMapper _mapper;

        public FranchisesController(IFranchiseService franchiseService,
            IMapper mapper)
        {
            _franchiseService = franchiseService;
            _mapper = mapper;
        }

        // GET: api/Franchises
        [ProducesResponseType(typeof(IEnumerable<FranchiseResponseDto>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FranchiseResponseDto>>> GetFranchises()
        {
            var franchises = await _franchiseService.GetFranchises();
            var franchiseResponseDtos = _mapper.Map<IEnumerable<FranchiseResponseDto>>(franchises);

            return franchiseResponseDtos.ToList();
        }

        // GET: api/Franchises/5
        [ProducesResponseType(typeof(FranchiseResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<FranchiseResponseDto>> GetFranchise(int id)
        {
            var franchise = await _franchiseService.GetFranchise(id);
            if (franchise == null)
            {
                return NotFound();
            }

            return _mapper.Map<FranchiseResponseDto>(franchise);
        }

        // PUT: api/Franchises/5
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFranchise(int id, 
            Franchise franchise)
        {
            if (id != franchise.Id)
            {
                return BadRequest();
            }

            var updatedFranchise = await _franchiseService.UpdateFranchise(franchise);
            if (updatedFranchise == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Franchises
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<ActionResult<FranchiseResponseDto>> PostFranchise(
            Franchise franchise)
        {
            var createdFranchise = await _franchiseService.CreateFranchise(franchise);
            var franchiseResponseDto = _mapper.Map<FranchiseResponseDto>(createdFranchise);

            return CreatedAtAction("GetFranchise", 
                new { id = franchiseResponseDto.Id },
                franchiseResponseDto);
        }

        // DELETE: api/Franchises/5
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFranchise(int id)
        {
            var deleted = await _franchiseService.DeleteFranchise(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        // GET: api/Franchises/5/movies
        [ProducesResponseType(typeof(IEnumerable<MovieInFranchiseDto>), StatusCodes.Status200OK)]
        [HttpGet("{id}/movies")]
        public async Task<ActionResult<IEnumerable<MovieInFranchiseDto>>> GetMoviesInFranchise(int id)
        {
            var movies = await _franchiseService.GetMoviesInFranchise(id);
            var movieInFranchiseDtos = movies
                .Select(m => _mapper.Map<MovieInFranchiseDto>(m));

            return movieInFranchiseDtos.ToList();
        }

        // GET: api/Franchises/5/characters
        [ProducesResponseType(typeof(IEnumerable<CharacterInFranchiseDto>), StatusCodes.Status200OK)]
        [HttpGet("{id}/characters")]
        public async Task<ActionResult<IEnumerable<CharacterInFranchiseDto>>> GetCharactersInFranchise(int id)
        {
            var characters = await _franchiseService.GetCharactersInFranchise(id);
            var characterInFranchiseDto = characters
                .Select(m => _mapper.Map<CharacterInFranchiseDto>(m));

            return characterInFranchiseDto.ToList();
        }
    }
}
