using CoursesShop.Data.Identity;
using CoursesShop.Infrastructure.Absracts;

namespace CoursesShop.Infrastructure.Interfaces
{
    public interface IRefershTokenRepository : IBaseRepository<UserRefreshToken>
    {
    }
}
