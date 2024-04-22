using CoursesShop.Infrastructure.Absracts;
using CoursesShop.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesShop.Infrastructure
{
    public static class MaduleInfrastructureDependacies
    {
        public static IServiceCollection AddInfrastructureDependacies(this IServiceCollection service)
        {
            service.AddTransient<IStudentRepository, StudentRepository>();
            return service;
        }
    }
}
