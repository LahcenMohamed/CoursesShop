using CoursesShop.Data.Entities;
using CoursesShop.Infrastructure.Bases;
using CoursesShop.Infrastructure.Interfaces;
using ECommerceCourse.DataAccess.DbContexts;

namespace CoursesShop.Infrastructure.Repositories
{
    public sealed class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(CoursesShopDbContext context) : base(context)
        {

        }
    }
}
