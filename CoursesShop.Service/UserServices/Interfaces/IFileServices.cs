using Microsoft.AspNetCore.Http;

namespace CoursesShop.Service.UserServices.Interfaces
{
    public interface IFileServices
    {
        public Task<string> UploadImageAsync(string Location, IFormFile Image);
    }
}
