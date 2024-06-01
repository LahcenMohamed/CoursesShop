using CoursesShop.Core.Features.Courses.Commands.Requests;
using CoursesShop.Data.Entities;

namespace CoursesShop.Core.Mapping.Courses
{
    public partial class CourseProfile
    {
        public void AddCourseMapper()
        {
            CreateMap<AddCourseRequest, Course>();
        }
    }
}
