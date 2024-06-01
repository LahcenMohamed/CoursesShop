using CoursesShop.API.Bases;
using CoursesShop.Core.Features.Courses.Commands.Requests;
using CoursesShop.Core.Features.Courses.Queries.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoursesShop.API.Controllers.Teachers
{
    [Route("api/Teacher/[controller]s")]
    [ApiController]
    [Authorize(Roles = "Teacher")]
    public sealed class CourseController : AppControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await Mediator.Send(new GetCoursesByTeacherIdRequest());
            return NewResult(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] AddCourseRequest request)
        {
            var response = await Mediator.Send(request);
            return NewResult(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateCourseRequest request)
        {
            var response = await Mediator.Send(request);
            return NewResult(response);
        }

        [HttpDelete("{courseId:guid}")]
        public async Task<IActionResult> Delete(string courseId)
        {
            var response = await Mediator.Send(new DeleteCourseFromTeacherRequest { CourseId = courseId });
            return NewResult(response);
        }
    }
}
