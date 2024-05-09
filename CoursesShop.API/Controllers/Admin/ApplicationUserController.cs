using CoursesShop.API.Bases;
using CoursesShop.Core.Features.User.Commands.Requsets;
using CoursesShop.Core.Features.User.Queries.Requsets;
using Microsoft.AspNetCore.Mvc;

namespace CoursesShop.API.Controllers.Admin
{
    [Route("api/Users")]
    [ApiController]
    public class ApplicationUserController : AppControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await Mediator.Send(new GetAllUsersRequest());
            return NewResult(response);
        }

        [HttpGet("Paginated")]
        public async Task<IActionResult> GetAllWithPagination([FromQuery] GetUsersWithPaginationRequest request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] AddUserRequest request)
        {
            var response = await Mediator.Send(request);
            return NewResult(response);
        }

        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromForm] ChangePasswordRequest request)
        {
            var response = await Mediator.Send(request);
            return NewResult(response);
        }

        [HttpDelete("{Id:guid}")]
        public async Task<IActionResult> Delete(string Id)
        {
            var response = await Mediator.Send(new DeleteUserRequest { Id = Id });
            return NewResult(response);
        }
    }
}
