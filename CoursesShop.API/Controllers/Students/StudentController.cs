using CoursesShop.API.Bases;
using CoursesShop.Core.Features.Students.Commands.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoursesShop.API.Controllers.Students
{
    [Route("api/[controller]s")]
    [ApiController]
    public sealed class StudentController : AppControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Add(AddStudentRequest request)
        {
            var response = await Mediator.Send(request);
            return NewResult(response);
        }
    }
}
