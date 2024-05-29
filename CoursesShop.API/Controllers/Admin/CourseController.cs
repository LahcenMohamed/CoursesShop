using CoursesShop.API.Bases;
using CoursesShop.Core.Features.Courses.Commands.Requests;
using CoursesShop.Core.Features.Courses.Queries.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CoursesShop.API.Controllers.Admin
{
    [Route("api/Admin/[controller]s")]
    [ApiController]
    public sealed class CourseController : AppControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await Mediator.Send(new GetAllCoursesRequest());
            return NewResult(response);
        }

        [HttpGet("Paginated")]
        public async Task<IActionResult> GetAllWithPagintion([FromQuery] GetCoursesWithPaginationRequest request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{Id:guid}")]
        public async Task<IActionResult> GetById(string Id)
        {
            var response = await Mediator.Send(new GetCourseByIdRequest { Id = Id });
            return NewResult(response);
        }

        [HttpDelete("{Id:guid}")]
        public async Task<IActionResult> Delete(string Id)
        {
            var response = await Mediator.Send(new DeleteCourseRequest { Id = Id });
            return NewResult(response);
        }
    }
}
