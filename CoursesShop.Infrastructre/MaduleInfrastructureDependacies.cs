using CoursesShop.Infrastructure.Absracts;
using CoursesShop.Infrastructure.Bases;
using CoursesShop.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CoursesShop.Infrastructure
{
    public static class MaduleInfrastructureDependacies
    {
        public static IServiceCollection AddInfrastructureDependacies(this IServiceCollection service)
        {
            service.AddTransient<IStudentRepository, StudentRepository>();
            service.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            return service;
        }
    }
}
