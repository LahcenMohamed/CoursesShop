using CoursesShop.Data.Entities;
using CoursesShop.Data.Helpers;

namespace CoursesShop.Service.Abstracts
{
    public interface IStudentServices
    {
        public Task<List<Student>> GetAllAsync();
        public IQueryable<Student> GetAllAsQueryable();
        public IQueryable<Student> FillterAsQueryable(StudentOrderingEnum orderBy, string search);
        public Task<Student> GetByIdAsync(string Id);
        public Task AddStudent(Student student);
        public Task DeleteAsync(string Id);
        public Task<bool> IsEmailExistAsync(string Email);
        public Task<bool> IsIdExistAsync(string Id);
    }
}
