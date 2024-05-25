using CoursesShop.API.Bases;
using CoursesShop.Core.Features.Authorization.Command.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CoursesShop.API.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : AppControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateRole([FromForm] AddRoleRequest request)
        {
            var response = await Mediator.Send(request);
            return NewResult(response);
        }
    }
}
