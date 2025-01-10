using Microsoft.AspNetCore.Mvc;
using P.Models;
using P.Services;

namespace P.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpPost("add")]
        public IActionResult AddPokemon(Pokemon pokemon)
        {
            try
            {
                _pokemonService.AddAsync(pokemon);
                return Ok(new { Message = "New pokemon added successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error occured during adding pokemon.", Error = ex.Message });
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllPokemon()
        {
            try
            {
                var pokemons = await _pokemonService.GetAllAsync();
                return Ok(pokemons);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "error while getting pokemon.", Error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPokemonById(int id)
        {
            try
            {
                var pokemon = await _pokemonService.GetByIdAsync(id);
                if (pokemon == null)
                {
                    return NotFound(new { Message = "Pokemon not found." });
                }
                return Ok(pokemon);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "error occurred while getting Pokemon.", Error = ex.Message });
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdatePokemon(int id, [FromBody] Pokemon updatedPokemon)
        {
            try
            {
                var existingPokemon = await _pokemonService.GetByIdAsync(id);
                if (existingPokemon == null)
                {
                    return NotFound(new { Message = "Pokemon not found." });
                }

                await _pokemonService.UpdateAsync(id, updatedPokemon);
                return Ok(new { Message = "Pokemon updated successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while updating the Pokemon.", Error = ex.Message });
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeletePokemonAsync(int id)
        {
            try
            {
                var existingPokemon = await _pokemonService.GetByIdAsync(id);
                if (existingPokemon == null)
                {
                    return NotFound(new { Message = "Pokemon not found." });
                }

                await _pokemonService.DeleteAsync(id);
                return Ok(new { Message = "Pokemon deleted successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while deleting the Pokemon.", Error = ex.Message });
            }
        }
    }
}
