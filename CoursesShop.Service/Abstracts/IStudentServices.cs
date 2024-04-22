using CoursesShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesShop.Service.Abstracts
{
    public interface IStudentServices
    {
        public Task<List<Student>> GetAllAsync();
    }
}
