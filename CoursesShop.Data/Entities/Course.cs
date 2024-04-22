using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesShop.Data.Entities
{
    public sealed class Course
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public double ReviewsAverge { get; set; }
        public string TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public List<Receipt> Receipts { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
