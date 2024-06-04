using CoursesShop.Data.Entities;
using CoursesShop.Infrastructure.Bases;
using CoursesShop.Infrastructure.DbContexts;
using CoursesShop.Infrastructure.Interfaces;

namespace CoursesShop.Infrastructure.Repositories
{
    public sealed class ReceiptRepository(CoursesShopDbContext context) : BaseRepository<Receipt>(context), IReceiptRepository
    {
    }
}
