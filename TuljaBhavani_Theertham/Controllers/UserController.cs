using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TuljaBhavani_Theertham.Models;
using TuljaBhavani_Theertham.Services;

namespace TuljaBhavani_Theertham.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AuthService _authService;

        public UserController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(UserModel userModel)
        {
            try
            {
                var result = await _authService.RegisterUser(userModel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(User user)
        {
            try
            {
                var token = await _authService.LoginUser(user.UserName, user.Password);
                if (token != null)
                {
                    return Ok(new { Token = token });
                }
                return Unauthorized("Invalid username or password");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
