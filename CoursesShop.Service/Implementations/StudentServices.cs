using CoursesShop.Data.Entities;
using CoursesShop.Infrastructure.Absracts;
using CoursesShop.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesShop.Service.Implementations
{
    public sealed class StudentServices(IStudentRepository studentRepository) : IStudentServices
    {
        private readonly IStudentRepository _studentRepository = studentRepository;
        public async Task<List<Student>> GetAllAsync()
        {
            return await _studentRepository.GetAllAsync();
        }
    }
}
