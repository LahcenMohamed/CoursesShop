using CoursesShop.Service.Abstracts;
using CoursesShop.Service.Implementations;
using CoursesShop.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CoursesShop.Service
{
    public static class MaduleServiceDependacies
    {
        public static IServiceCollection AddServiceDependacies(this IServiceCollection service)
        {
            service.AddTransient<IStudentServices, StudentServices>();
            service.AddTransient<ITeacherServices, TeacherServices>();
            service.AddTransient<IUserServices, UserServices>();
            service.AddTransient<IAuthorizationServices, AutorizationServices>();
            service.AddTransient<IAuthenticationServices, AuthenticationServices>();
            service.AddTransient<IFileServices, FileServices>();
            service.AddTransient<IEmailServices, EmailServices>();
            return service;
        }
    }
}
