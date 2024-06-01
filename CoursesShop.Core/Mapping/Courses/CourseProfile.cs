using AutoMapper;

namespace CoursesShop.Core.Mapping.Courses
{
    public partial class CourseProfile : Profile
    {
        public CourseProfile()
        {
            GetCourseMapper();
            GetCourseWithPagintedMapping();
            AddCourseMapper();
            UpdateCourseMapper();
        }
    }
}
