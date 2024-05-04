using Microsoft.AspNetCore.Http;

namespace CoursesShop.Service.Interfaces
{
    public interface IFileServices
    {
        public Task<string> UploadImage(string Location, IFormFile Image);
    }
}
