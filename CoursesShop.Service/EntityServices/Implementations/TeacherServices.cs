using CoursesShop.Data.Entities;
using CoursesShop.Infrastructure.Interfaces;
using CoursesShop.Service.EntityServices.Interfaces;
using CoursesShop.Service.UserServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CoursesShop.Service.EntityServices.Implementations
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
                ImageUrl = await _fileServices.UploadImageAsync("Images/Teachers", Image);
            }
            teacher.imageUrl = ImageUrl;
            await _teacherRepository.AddAsync(teacher);
        }

        public async Task DeleteAsync(string Id)
        {
            var teacher = GetById(Id);
            await _teacherRepository.DeleteAsync(teacher);
        }

        public IQueryable<Teacher> FillterAllAsQueryable(string search)
        {
            return _teacherRepository.GetTableNoTracking().Where(x => x.FullName.Contains(search) ||
                                                                      x.Email.Contains(search));
        }

        public IQueryable<Teacher> GetAllAsQueryable()
        {
            return _teacherRepository.GetTableNoTracking();
        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            return await _teacherRepository.GetTableNoTracking().ToListAsync();
        }

        public Teacher GetById(string Id)
        {
            return _teacherRepository.GetTableNoTracking().FirstOrDefault(x => x.Id == Id);
        }

        public async Task<bool> IsEmailExistAsync(string Email)
        {
            return _teacherRepository.GetTableNoTracking().Any(x => x.Email == Email);
        }

        public bool IsIdExist(string id)
        {
            return _teacherRepository.GetTableNoTracking().Any(x => x.Id == id);
        }
    }
}
