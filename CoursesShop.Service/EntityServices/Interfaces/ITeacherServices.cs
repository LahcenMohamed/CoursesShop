using CoursesShop.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace CoursesShop.Service.EntityServices.Interfaces
{
    public interface ITeacherServices
    {
        public Task<List<Teacher>> GetAllAsync();
        public IQueryable<Teacher> GetAllAsQueryable();
        public IQueryable<Teacher> FillterAllAsQueryable(string search);
        public Teacher GetById(string Id);
        public Task AddAsync(Teacher teacher, IFormFile? Image);
        public Task<bool> IsEmailExistAsync(string Email);
        public bool IsIdExist(string id);
        public Task DeleteAsync(string Id);
    }
}
