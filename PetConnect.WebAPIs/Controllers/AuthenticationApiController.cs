using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("signup")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Signup([FromBody] UserServiceModel userInfo)
        { 

            int rowInserted=  await _authService.SignupAsync(userInfo);
            if (rowInserted ==-1)
            {
                ModelState.AddModelError("Custome Error", "User already exists.");
                return BadRequest(ModelState);
            }
            else if(rowInserted > 0 ) {
                return CreatedAtAction("signup", new { email = userInfo.Email }, userInfo);
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
