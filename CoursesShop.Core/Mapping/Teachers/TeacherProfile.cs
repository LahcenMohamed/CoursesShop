using AutoMapper;

namespace CoursesShop.Core.Mapping.Teachers
{
    public sealed partial class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            AddTeacherMapping();
        }
    }
}
