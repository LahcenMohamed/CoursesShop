using CoursesShop.Data.Entities;
using CoursesShop.Infrastructure.Absracts;
using ECommerceCourse.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesShop.Infrastructure.Repositories
{
    public sealed class StudentRepository(CoursesShopDbContext context) : IStudentRepository
    {
        private readonly CoursesShopDbContext _context = context;
        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }
    }
}
