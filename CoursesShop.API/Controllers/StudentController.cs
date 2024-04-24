using CoursesShop.Core.Features.Students.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoursesShop.API.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class StudentController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var response = await _mediator.Send(new GetAllStudentsQuery());
            return Ok(response);
        }
        [HttpGet("{Id:guid}")]
        public async Task<IActionResult> GetById(string Id)
        {
            var response = await _mediator.Send(new GetStudentByIdQuery() { Id = Id });
            return Ok(response);
        }
    }
}
