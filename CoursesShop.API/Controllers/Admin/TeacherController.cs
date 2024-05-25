using CoursesShop.API.Bases;
using CoursesShop.Core.Features.Teachers.Commands.Requests;
using CoursesShop.Core.Features.Teachers.Queries.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CoursesShop.API.Controllers.Admin
{
    [Route("api/Admin/[controller]s")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public sealed class TeacherController : AppControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await Mediator.Send(new GetAllTeachersRequest());
            return NewResult(response);
        }
        [HttpGet("Pagination")]
        public async Task<IActionResult> GetAllWithPaginationAsync([FromQuery] GetTeachersWithPaginationRequest request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            var response = await Mediator.Send(new GetTeacherByIdRequest { Id = id });
            return NewResult(response);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var response = await Mediator.Send(new DeleteTeacherRequest { Id = id });
            return NewResult(response);
        }
    }
}
