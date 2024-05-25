using CoursesShop.API.Bases;
using CoursesShop.Core.Features.Authentication.Commands.Requests;
using CoursesShop.Core.Features.Authentication.Queries.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CoursesShop.API.Controllers.Authentications
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : AppControllerBase
    {
        [HttpPost("Signin")]
        public async Task<IActionResult> Signin(SigninRequest request)
        {
            var response = await Mediator.Send(request);
            return NewResult(response);
        }

        [HttpPost("Signup")]
        public async Task<IActionResult> Signup(SignupRequest request)
        {
            var response = await Mediator.Send(request);
            return NewResult(response);
        }

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken(RefreshTokenRequest request)
        {
            var response = await Mediator.Send(request);
            return NewResult(response);
        }

        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> SendEmail([FromQuery] ConfirmEmailRequest request)
        {
            var response = await Mediator.Send(request);
            return NewResult(response);
        }

        [HttpPost("SendResetPasswordCode")]
        public async Task<IActionResult> SendResetPasswordCode(SendResetPasswordCodeRequest request)
        {
            var response = await Mediator.Send(request);
            return NewResult(response);
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> SendResetPasswordCode(ResetPasswordRequest request)
        {
            var response = await Mediator.Send(request);
            return NewResult(response);
        }
    }
}
