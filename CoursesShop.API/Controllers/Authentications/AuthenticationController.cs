using CoursesShop.API.Bases;
using CoursesShop.Core.Features.Authentication.Commands.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CoursesShop.API.Controllers.Authentications
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : AppControllerBase
    {
        [HttpPost("Signup")]
        public async Task<IActionResult> Signup([FromForm] SignupRequest request)
        {
            var response = await Mediator.Send(request);
            return NewResult(response);
        }
        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromForm] RefreshTokenRequest request)
        {
            var response = await Mediator.Send(request);
            return NewResult(response);
        }
    }
}
