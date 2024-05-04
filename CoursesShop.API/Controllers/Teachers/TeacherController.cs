using CoursesShop.API.Bases;
using CoursesShop.Core.Features.Teachers.Commands.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CoursesShop.API.Controllers.Teachers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController() : AppControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] AddTeacherRequest request)
        {
            var response = await Mediator.Send(request);
            return NewResult(response);
        }
    }
}
