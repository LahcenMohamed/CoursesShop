using CoursesShop.Data.Entities;
using CoursesShop.Infrastructure.Interfaces;
using CoursesShop.Service.EntityServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CoursesShop.Service.EntityServices.Implementations
{
    public sealed class CourseServices(ICourseRepository courseRepository) : ICourseServices
    {
        private readonly ICourseRepository _courseRepository = courseRepository;

        public Task AddAsync(Course course, IFormFile? Image)
        {
            throw new NotImplementedException();
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
    }
}
