using CoursesShop.Core.Features.Courses.Queries.Results;
using CoursesShop.Data.Entities;

namespace CoursesShop.Core.Mapping.Courses
{
    public partial class CourseProfile
    {
        public void GetCourseMapper()
        {
            CreateMap<Course, GetCourseResult>().ForMember(x => x.TeacherName, opt => opt.MapFrom(course => course.Teacher.FullName));
        }
    }
}
