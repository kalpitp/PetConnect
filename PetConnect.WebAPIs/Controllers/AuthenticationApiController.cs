using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PetConnect.DataAccess.Models;
using PetConnect.DataAccess.Repository;
using PetConnect.Services.DTOs;
using PetConnect.Services.Interfaces;

namespace PetConnect.WebAPIs.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationApiController : ControllerBase
    {
        private readonly IAuthenticationService _authService;

        public AuthenticationApiController(IAuthenticationService authService) {
            _authService = authService;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LoginServiceModel loginData)
        {
            
            var user= await _authService.LoginAsync(loginData);

            if (user != null)
            {
                return Ok(user);
            }
            return Unauthorized("Invalid Email Id or Password");
        }


        [HttpGet("getuser/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserById(int id)
        {
            if(id == 0) { return BadRequest(); }
            var user = await _authService.GetUserByIdAsync(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }


        [HttpPost("signup")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Signup([FromBody] UserServiceModel userInfo)
        { 
            if(userInfo == null) { return BadRequest(); }

            int rowInserted=  await _authService.SignupAsync(userInfo);
            if (rowInserted ==-1)
            {
                ModelState.AddModelError("Error", "User already exists.");
                return BadRequest(ModelState);
            }
            else if(rowInserted > 0 ) {
                return StatusCode(StatusCodes.Status201Created);
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
