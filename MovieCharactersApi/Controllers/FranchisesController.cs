using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [ProducesResponseType(typeof(IEnumerable<Franchise>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Franchise>>> GetFranchises()
        {
            var franchises = await _franchiseService.GetFranchises();

            return franchises.ToList();
        }

        // GET: api/Franchises/5
        [ProducesResponseType(typeof(Franchise), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Franchise>> GetFranchise(int id)
        {
            var franchise = await _franchiseService.GetFranchise(id);
            if (franchise == null)
            {
                return NotFound();
            }

            return franchise;
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
        public async Task<ActionResult<Franchise>> PostFranchise(Franchise franchise)
        {
            var createdFranchise = await _franchiseService.CreateFranchise(franchise);


            return CreatedAtAction("GetFranchise", 
                new { id = createdFranchise.Id }, 
                createdFranchise);
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
