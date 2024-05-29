using CoursesShop.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace CoursesShop.Service.EntityServices.Interfaces
{
    public interface ICourseServices
    {
        public Task<List<Course>> GetAllAsync();
        public IQueryable<Course> GetAllAsQueryable();
        public IQueryable<Course> FillterAllAsQueryable(string search);
        public Course GetById(string Id);
        public Task AddAsync(Course course, IFormFile? Image);
        public bool IsIdExist(string id);
        public Task DeleteAsync(string Id);
    }
}
