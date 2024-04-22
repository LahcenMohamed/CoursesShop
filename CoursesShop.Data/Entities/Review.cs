using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesShop.Data.Entities
{
    public sealed class Review
    {
        public string Id { get; set; }
        public double Evalution { get; set; }
        public string? Comment { get; set; }
        public string CourseId { get; set; }
        public Course Course { get; set; }
        public string StudentId { get; set; }
        public Student Student { get; set; }
    }
}
