using CoursesShop.Data.Entities;
using CoursesShop.Infrastructure.Bases;
using CoursesShop.Infrastructure.DbContexts;
using CoursesShop.Infrastructure.Interfaces;

namespace CoursesShop.Infrastructure.Repositories
{
    public class ReviewRepository(CoursesShopDbContext context) : BaseRepository<Review>(context), IReviewRepository
    {

    }
}
