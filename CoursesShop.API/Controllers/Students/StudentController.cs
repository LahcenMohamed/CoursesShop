using CoursesShop.API.Bases;
using CoursesShop.Core.Features.Receipts.Commands.Requests;
using CoursesShop.Core.Features.Students.Commands.Models;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Student")]
        [HttpPost("Receipts")]
        public async Task<IActionResult> AddReceipt(AddReceiptRequest request)
        {
            var response = await Mediator.Send(request);
            return NewResult(response);
        }
    }
}
