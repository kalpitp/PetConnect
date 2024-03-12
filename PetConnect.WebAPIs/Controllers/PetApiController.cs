using Microsoft.AspNetCore.Mvc;
using PetConnect.Services.DTOs;
using PetConnect.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetConnect.WebAPIs.Controllers
{
    [Route("api/pet")]
    [ApiController]
    public class PetApiController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetApiController(IPetService petService)
        {
            _petService = petService;
        }

        // GET: api/<PetApiController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var pets = await _petService.GetAllPets();
                if (pets != null && pets.Any())
                {
                    return Ok(pets);
                }

                return NotFound("Pets not found");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching pets: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred while fetching pets.");
            }

        }

        // GET api/<PetApiController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("Invalid Id");
                }
                var pet = await _petService.GetPetById(id);
                if (pet != null)
                {
                    return Ok(pet);
                }

                return NotFound("Pet Not Found");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching pet: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred while fetching pet.");
            }
        }

        // POST api/<PetApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PetApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PetApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
