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
        private readonly IMoviesService _moviesService;
        private readonly IMapper _mapper;

        public MoviesController(
            IMoviesService moviesService,
            IMapper mapper)
        {
            _moviesService = moviesService;
            _mapper = mapper;
        }

        // GET: api/Movies
        [ProducesResponseType(typeof(IEnumerable<MovieResponseDto>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieResponseDto>>> GetMovies()
        {
            var movies = await _moviesService.GetMovies();
            var movieResponseDtos = _mapper.Map<IEnumerable<MovieResponseDto>>(movies);

            return movieResponseDtos.ToList();
        }

        // GET: api/Movies/5
        [ProducesResponseType(typeof(MovieResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id,
            MovieUpdateRequestDto movieToBeUpdated)
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
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
        [ProducesResponseType(typeof(MovieResponseDto), StatusCodes.Status201Created)]
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
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
