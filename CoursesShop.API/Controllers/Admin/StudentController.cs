using CoursesShop.API.Bases;
using CoursesShop.Core.Features.Students.Commands.Models;
using CoursesShop.Core.Features.Students.Queries.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoursesShop.API.Controllers.Admin
{
    [Route("api/Admin/[controller]s")]
    [ApiController]
    [Authorize]
    public class StudentController : AppControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await Mediator.Send(new GetAllStudentsRequest());
            return NewResult(response);
        }

        [HttpGet("Paginated")]
        public async Task<IActionResult> GetAllWithPaginated([FromQuery] GetStudentPagintedRequest request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{Id:guid}")]
        public async Task<IActionResult> GetById(string Id)
        {
            var response = await Mediator.Send(new GetStudentByIdRequest() { Id = Id });
            return NewResult(response);
        }

        [HttpDelete("{Id:guid}")]
        public async Task<IActionResult> Delete(string Id)
        {
            var response = await Mediator.Send(new DeleteStudentRequest() { Id = Id });
            return NewResult(response);
        }
    }
}
