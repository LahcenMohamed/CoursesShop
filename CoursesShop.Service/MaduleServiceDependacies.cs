using CoursesShop.Service.EntityServices.Implementations;
using CoursesShop.Service.EntityServices.Interfaces;
using CoursesShop.Service.UserServices.Implementations;
using CoursesShop.Service.UserServices.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CoursesShop.Service
{
    public static class MaduleServiceDependacies
    {
        public static IServiceCollection AddServiceDependacies(this IServiceCollection service)
        {
            service.AddTransient<IStudentServices, StudentServices>();
            service.AddTransient<ITeacherServices, TeacherServices>();
            service.AddTransient<ICourseServices, CourseServices>();
            service.AddTransient<IReviewServices, ReviewServices>();
            service.AddTransient<IUserServices, UsersServices>();
            service.AddTransient<IAuthorizationServices, AutorizationServices>();
            service.AddTransient<IAuthenticationServices, AuthenticationServices>();
            service.AddTransient<IFileServices, FileServices>();
            service.AddTransient<IEmailServices, EmailServices>();
            return service;
        }
    }
}
