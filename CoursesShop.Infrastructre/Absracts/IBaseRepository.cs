using CoursesShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesShop.Infrastructure.Absracts
{
    public interface IBaseRepository<T>
    {
        public Task<List<T>> GetAllAsync();
    }
}
