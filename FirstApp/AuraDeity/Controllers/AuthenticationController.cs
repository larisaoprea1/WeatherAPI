using DataAccess.Entities;
using Interfaces.Comands;
using Interfaces.Querries;
using Logic.Queries.Services;
using Microsoft.AspNetCore.Mvc;
using Models.Authentication;

namespace AuraDeity.Controllers
{
    [ApiController]
    
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationQuery _authenticationQuery;
        private readonly IAuthenticationComand _authenticationComand;

        public AuthenticationController(IAuthenticationQuery authenticationQuery, IAuthenticationComand authenticationComand)
        {
            _authenticationQuery = authenticationQuery;
            _authenticationComand = authenticationComand;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var token = await _authenticationQuery.LoginIfUserExistsAsync(loginModel);
            if (string.IsNullOrEmpty(token))
            {
                return NotFound();
            }

            return Ok(token);
        }
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignUpModel signUpModel)
        {
            var processResult = await _authenticationComand.SignUpAsync(signUpModel);
            if (string.IsNullOrEmpty(processResult))
            {
                return BadRequest();
            }
            return Ok(processResult);

        }
    }
}
