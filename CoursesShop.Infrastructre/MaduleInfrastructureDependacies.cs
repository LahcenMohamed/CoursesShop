using CoursesShop.Infrastructure.Absracts;
using CoursesShop.Infrastructure.Bases;
using CoursesShop.Infrastructure.Interfaces;
using CoursesShop.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CoursesShop.Infrastructure
{
    public static class MaduleInfrastructureDependacies
    {
        public static IServiceCollection AddInfrastructureDependacies(this IServiceCollection service)
        {
            service.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            service.AddTransient<IStudentRepository, StudentRepository>();
            service.AddTransient<ITeacherRepository, TeacherRepository>();
            service.AddTransient<IRefershTokenRepository, RefershTokenRepository>();
            service.AddTransient<ICourseRepository, CourseRepository>();
            service.AddTransient<IReviewRepository, ReviewRepository>();


            return service;
        }
    }
}
