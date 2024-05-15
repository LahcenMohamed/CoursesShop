using CoursesShop.Data.Identity;
using CoursesShop.Infrastructure.Bases;
using CoursesShop.Infrastructure.Interfaces;
using ECommerceCourse.DataAccess.DbContexts;

namespace CoursesShop.Infrastructure.Repositories
{
    public sealed class RefershTokenRepository : BaseRepository<UserRefreshToken>, IRefershTokenRepository
    {
        public RefershTokenRepository(CoursesShopDbContext context) : base(context)
        {

        }
    }
}
