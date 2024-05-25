using CoursesShop.Data.Entities;
using CoursesShop.Infrastructure.Absracts;
using CoursesShop.Infrastructure.Bases;
using CoursesShop.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace CoursesShop.Infrastructure.Repositories
{
    public sealed class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        private readonly DbSet<Student> _students;
        public StudentRepository(CoursesShopDbContext context) : base(context)
        {
            _students = _dbContext.Set<Student>();
        }
    }
}
