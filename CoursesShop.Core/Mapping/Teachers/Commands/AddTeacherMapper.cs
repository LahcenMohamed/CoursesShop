using AutoMapper;
using CoursesShop.Core.Features.Teachers.Commands.Requests;
using CoursesShop.Data.Entities;

namespace CoursesShop.Core.Mapping.Teachers
{
    public sealed partial class TeacherProfile : Profile
    {
        public void AddTeacherMapping()
        {
            CreateMap<AddTeacherRequest, Teacher>();
        }
    }
}
