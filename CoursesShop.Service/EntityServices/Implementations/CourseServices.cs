using CoursesShop.Data.Entities;
using CoursesShop.Infrastructure.Interfaces;
using CoursesShop.Service.EntityServices.Interfaces;
using CoursesShop.Service.UserServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CoursesShop.Service.EntityServices.Implementations
{
    public sealed class CourseServices(ICourseRepository courseRepository, IFileServices fileServices) : ICourseServices
    {
        private readonly ICourseRepository _courseRepository = courseRepository;
        private readonly IFileServices _fileServices = fileServices;

        public async Task AddAsync(Course course, IFormFile? Image)
        {
            if (Image is not null)
            {
                course.ImageUrl = await _fileServices.UploadImageAsync("Images/Courses", Image);
            }
            await _courseRepository.AddAsync(course);
        }

        public async Task UpdateAsync(Course course, IFormFile? Image)
        {
            var courseBefor = GetById(course.Id);
            course.ImageUrl = courseBefor.ImageUrl;
            if (Image is not null)
            {
                course.ImageUrl = await _fileServices.UploadImageAsync("Images/Courses", Image);
            }
            await _courseRepository.UpdateAsync(course);
        }

        public async Task<List<Course>> GetByTeacherIdAsync(string teacherId)
        {
            var courses = await _courseRepository.GetTableNoTracking().Where(x => x.TeacherId == teacherId).ToListAsync();
            return courses;
        }


        public async Task DeleteAsync(string Id)
        {
            var course = GetById(Id);
            await _courseRepository.DeleteAsync(course);
        }

        public IQueryable<Course> FillterAllAsQueryable(string search)
        {
            decimal price = -1m;
            decimal.TryParse(search, out price);
            return _courseRepository.GetTableNoTracking().Include(t => t.Teacher).Where(x => x.Title.Contains(search) ||
                                                                     x.Description.Contains(search) ||
                                                                     x.Price == price);
        }

        public IQueryable<Course> GetAllAsQueryable()
        {
            return _courseRepository.GetTableNoTracking().Include(x => x.Teacher);
        }

        public async Task<List<Course>> GetAllAsync()
        {
            return await _courseRepository.GetTableNoTracking().Include(x => x.Teacher).ToListAsync();
        }

        public Course GetById(string Id)
        {
            return _courseRepository.GetTableNoTracking().Include(x => x.Teacher).FirstOrDefault(x => x.Id == Id);
        }

        public bool IsIdExist(string id)
        {
            return _courseRepository.GetTableNoTracking().Any(x => x.Id == id);
        }

        public bool IsCourseIdToTeacherId(string courseId, string teacherId)
        {
            return _courseRepository.GetTableNoTracking().Any(x => x.Id == courseId && x.TeacherId == teacherId);
        }


    }
}
