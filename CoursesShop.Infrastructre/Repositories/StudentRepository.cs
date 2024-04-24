using CoursesShop.Data.Entities;
using CoursesShop.Infrastructure.Absracts;
using CoursesShop.Infrastructure.Bases;
using ECommerceCourse.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesShop.Infrastructure.Repositories
{
    public sealed class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        private readonly  DbSet<Student> _students;
        public StudentRepository(CoursesShopDbContext context):base(context)
        {
            _students = _dbContext.Set<Student>();
        }
    }
}
