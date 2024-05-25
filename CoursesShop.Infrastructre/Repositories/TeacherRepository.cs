using CoursesShop.Data.Entities;
using CoursesShop.Infrastructure.Bases;
using CoursesShop.Infrastructure.DbContexts;
using CoursesShop.Infrastructure.Interfaces;

namespace CoursesShop.Infrastructure.Repositories
{
    public sealed class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(CoursesShopDbContext context) : base(context)
        {

        }
    }
}
