namespace CoursesShop.Service.UserServices.Interfaces
{
    public interface IEmailServices
    {
        public Task<string> SendEmailAsync(string email, string Message, string? reason);
    }
}
