using CoursesShop.Data.Entities;
using CoursesShop.Infrastructure.Interfaces;
using CoursesShop.Service.Interfaces;
using Microsoft.AspNetCore.Http;

namespace CoursesShop.Service.Implementations
{
    public sealed class TeacherServices(ITeacherRepository teacherRepository, IFileServices fileServices) : ITeacherServices
    {
        private readonly ITeacherRepository _teacherRepository = teacherRepository;
        private readonly IFileServices _fileServices = fileServices;

        public async Task AddAsync(Teacher teacher, IFormFile? Image)
        {
            string ImageUrl = null;
            if (Image is not null)
            {
                ImageUrl = await _fileServices.UploadImage("Images/Teachers", Image);
            }
            teacher.imageUrl = ImageUrl;
            await _teacherRepository.AddAsync(teacher);
        }

        public async Task<bool> IsEmailExistAsync(string Email)
        {
            return _teacherRepository.GetTableNoTracking().Any(x => x.Email == Email);
        }
    }
}
