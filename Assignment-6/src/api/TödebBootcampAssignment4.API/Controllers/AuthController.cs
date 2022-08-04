using Microsoft.AspNetCore.Mvc;
using TödebBootcampAssignment4.BusinessLayer.Features.Abstract;
using TödebBootcampAssignment4.DTOs.AuthDto;

namespace TödebBootcampAssignment4.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public IActionResult Login(LoginDto loginUserDto)
        {
            return Ok(_authService.Login(loginUserDto));
        }
    }
}
