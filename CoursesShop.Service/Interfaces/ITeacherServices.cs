using CoursesShop.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace CoursesShop.Service.Interfaces
{
    public interface ITeacherServices
    {
        public Task AddAsync(Teacher teacher, IFormFile? Image);
        public Task<bool> IsEmailExistAsync(string Email);
    }
}
