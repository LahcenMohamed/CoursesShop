using CoursesShop.Core.Features.Courses.Queries.Results;
using CoursesShop.Core.Wrapper;
using CoursesShop.Data.Entities;

namespace CoursesShop.Core.Mapping.Courses
{
    public partial class CourseProfile
    {
        public void GetCourseWithPagintedMapping()
        {
            CreateMap<PaginatedResult<Course>, PaginatedResult<GetCourseResult>>();

        }
    }
}
