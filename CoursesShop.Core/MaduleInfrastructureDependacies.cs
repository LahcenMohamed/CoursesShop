using CoursesShop.Infrastructure.Absracts;
using CoursesShop.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CoursesShop.Infrastructure
{
    public static class MaduleCoreDependacies
    {
        public static IServiceCollection AddCoreDependacies(this IServiceCollection service)
        {
            service.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            return service;
        }
    }
}
