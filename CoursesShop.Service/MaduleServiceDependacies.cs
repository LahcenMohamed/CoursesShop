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
            service.AddTransient<IFileServices, FileServices>();
            return service;
        }
    }
}
