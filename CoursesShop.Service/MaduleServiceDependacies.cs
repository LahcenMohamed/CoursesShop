using CoursesShop.Infrastructure.Absracts;
using CoursesShop.Infrastructure.Repositories;
using CoursesShop.Service.Abstracts;
using CoursesShop.Service.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesShop.Service
{
    public static class MaduleServiceDependacies
    {
        public static IServiceCollection AddServiceDependacies(this IServiceCollection service)
        {
            service.AddTransient<IStudentServices, StudentServices>();
            return service;
        }
    }
}
