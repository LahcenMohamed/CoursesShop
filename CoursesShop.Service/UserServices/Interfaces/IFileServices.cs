using Microsoft.AspNetCore.Http;

namespace CoursesShop.Service.UserServices.Interfaces
{
    public interface IFileServices
    {
        public Task<string> UploadImage(string Location, IFormFile Image);
    }
}
