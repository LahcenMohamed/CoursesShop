using CoursesShop.API.Bases;
using CoursesShop.Core.Features.Reviews.Commands.Requests;
using CoursesShop.Core.Features.Reviews.Queries.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoursesShop.API.Controllers.Admin
{
    [Route("api/[controller]s")]
    [ApiController]
    public sealed class ReviewController : AppControllerBase
    {
        [HttpGet("{CourseId:guid}")]
        public async Task<IActionResult> GetAllByCourseId(string CourseId)
        {
            var response = await Mediator.Send(new GetReviewsByCourseIdRequest { CourseId = CourseId });
            return NewResult(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{Id:guid}")]
        public async Task<IActionResult> Delete(string Id)
        {
            var response = await Mediator.Send(new DeleteReviewRequest { Id = Id });
            return NewResult(response);
        }
    }
}
