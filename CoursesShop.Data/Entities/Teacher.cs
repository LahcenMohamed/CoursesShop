using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesShop.Data.Entities
{
    public sealed class Teacher
    {
        public string Id { get; set; }
        [Length(5, 100)]
        [Required]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string imageUrl { get; set; }
        public List<Course> Courses { get; set; }
    }
}
