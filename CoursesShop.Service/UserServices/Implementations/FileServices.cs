using CoursesShop.Service.UserServices.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace CoursesShop.Service.UserServices.Implementations
{
    public sealed class FileServices(IWebHostEnvironment webHostEnvironment) : IFileServices
    {
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

        public async Task<string> UploadImage(string Location, IFormFile Image)
        {
            var path = _webHostEnvironment.WebRootPath + "/" + Location + "/";
            var fileName = Guid.NewGuid().ToString().Replace("-", string.Empty) + Path.GetExtension(Image.FileName);
            var FullPath = path + fileName;
            using (FileStream fileStream = File.Create(FullPath))
            {
                await Image.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
            }

            return "/" + Location + "/" + fileName;
        }
    }
}
