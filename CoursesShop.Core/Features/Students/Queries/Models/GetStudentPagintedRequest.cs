using CoursesShop.Core.Wrapper;
using CoursesShop.Data.Entities;
using CoursesShop.Data.Helpers;
using MediatR;

namespace CoursesShop.Core.Features.Students.Queries.Models
{
    public sealed class GetStudentPagintedRequest : IRequest<PaginatedResult<Student>>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; } = 0;
        public StudentOrderingEnum OrderBy { get; set; }
        public string? Search { get; set; }
    }
}
