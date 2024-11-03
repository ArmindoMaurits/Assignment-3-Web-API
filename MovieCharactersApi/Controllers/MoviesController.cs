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
    public class MoviesController : ControllerBase
    {
        private readonly MoviesService _moviesService;
        private readonly IMapper _mapper;

        public MoviesController(
            MoviesService moviesService,
            IMapper mapper)
        {
            _moviesService = moviesService;
            _mapper = mapper;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieResponseDto>>> GetMovies()
        {
            var movies = await _moviesService.GetMovies();
            var movieResponseDtos = _mapper.Map<IEnumerable<MovieResponseDto>>(movies);

            return movieResponseDtos.ToList();
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieResponseDto>> GetMovie(int id)
        {
            var movie = await _moviesService.GetMovie(id);
            if (movie == null)
            {
                return NotFound();
            }

            return _mapper.Map<MovieResponseDto>(movie);
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id,
            MovieResponseDto movieToBeUpdated)
        {
            if (id != movieToBeUpdated.Id)
            {
                return BadRequest();
            }

            var movie = _mapper.Map<Movie>(movieToBeUpdated);
            var updatedMovie = await _moviesService.UpdateMovie(movie);
            if (updatedMovie == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // PATCH: api/Movies/5/Characters
        [HttpPatch("{id}/Characters")]
        public async Task<IActionResult> PatchCharactersInMovie(int id,
            CharactersInMovieUpdateRequestDto charactersInMovieUpdateRequestDto)
        {
            if (!charactersInMovieUpdateRequestDto.CharacterIds.Any())
            {
                return BadRequest();
            }

            var updated = await _moviesService.UpdateCharactersInMovie(id,
                charactersInMovieUpdateRequestDto.CharacterIds);
            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MovieResponseDto>> PostMovie(
            MovieCreateRequestDto movieCreateRequestDto)
        {
            var movie = _mapper.Map<Movie>(movieCreateRequestDto);
            var createdMovie = await _moviesService.CreateMovie(movie);
            var movieResponseDto = _mapper.Map<MovieResponseDto>(createdMovie);

            return CreatedAtAction("GetMovie",
                new { id = movieResponseDto.Id },
                movieResponseDto);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var deleted = await _moviesService.DeleteMovie(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
