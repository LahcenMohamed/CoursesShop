using CoursesShop.Data.Entities;
using CoursesShop.Infrastructure.Bases;
using CoursesShop.Infrastructure.DbContexts;
using CoursesShop.Infrastructure.Interfaces;

namespace CoursesShop.Infrastructure.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(CoursesShopDbContext context) : base(context)
        {

        }
    }
}
