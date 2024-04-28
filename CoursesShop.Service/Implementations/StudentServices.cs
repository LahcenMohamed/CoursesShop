using CoursesShop.Data.Entities;
using CoursesShop.Data.Helpers;
using CoursesShop.Infrastructure.Absracts;
using CoursesShop.Service.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace CoursesShop.Service.Implementations
{
    public sealed class StudentServices(IStudentRepository studentRepository) : IStudentServices
    {
        private readonly IStudentRepository _studentRepository = studentRepository;

        public async Task AddStudent(Student student)
        {
            student.Id = Guid.NewGuid().ToString();
            await _studentRepository.AddAsync(student);
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _studentRepository.GetTableNoTracking().ToListAsync();
        }

        public async Task<Student> GetByIdAsync(string Id)
        {
            var student = await _studentRepository.GetByIdAsync(Id);
            return student;
        }

        public async Task<bool> IsEmailExistAsync(string Email)
        {
            return _studentRepository.GetTableNoTracking().Any(x => x.Email == Email);
        }

        public async Task DeleteAsync(string Id)
        {
            Student student = await GetByIdAsync(Id);
            await _studentRepository.DeleteAsync(student);
        }

        public async Task<bool> IsIdExistAsync(string Id)
        {
            return _studentRepository.GetTableNoTracking().Any(x => x.Id == Id);
        }

        public IQueryable<Student> GetAllAsQueryable()
        {
            return _studentRepository.GetTableNoTracking();
        }

        public IQueryable<Student> FillterAsQueryable(StudentOrderingEnum orderBy, string search)
        {
            var querable = _studentRepository.GetTableNoTracking().Where(x => x.FullName.Contains(search) || x.Email.Contains(search));

            return orderBy switch
            {
                StudentOrderingEnum.Id => querable.OrderBy(x => x.Id),
                StudentOrderingEnum.FullName => querable.OrderBy(x => x.FullName),
                StudentOrderingEnum.Email => querable.OrderBy(x => x.Email),
                _ => querable
            };
        }
    }
}
