using CoursesShop.Core.Wrapper;
using CoursesShop.Data.Entities;
using MediatR;

namespace CoursesShop.Core.Features.Students.Queries.Models
{
    public sealed class GetStudentPagintedRequest : IRequest<PaginatedResult<Student>>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; } = 0;
        public string? Search { get; set; }
    }
}
