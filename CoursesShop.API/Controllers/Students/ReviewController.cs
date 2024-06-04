using CoursesShop.API.Bases;
using CoursesShop.Core.Features.Reviews.Commands.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoursesShop.API.Controllers.Students
{
    [Route("api/Student/[controller]s")]
    [ApiController]
    [Authorize(Roles = "Student")]
    public class ReviewController : AppControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddAsync(AddReviewRequest request)
        {
            var response = await Mediator.Send(request);
            return NewResult(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateReviewRequest request)
        {
            var response = await Mediator.Send(request);
            return NewResult(response);
        }

        [HttpDelete("{Id:guid}")]
        public async Task<IActionResult> Delete(string Id)
        {
            var response = await Mediator.Send(new DeleteReviewByStudentRequest { Id = Id });
            return NewResult(response);
        }
    }
}
