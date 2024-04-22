
namespace CoursesShop.Data.Entities
{
    public sealed class Receipt
    {
        public string Id { get; set; }
        public decimal Price { get; set; }
        public DateTime DateAndTime { get; set; }
        public string CourseId { get; set; }
        public Course Course { get; set; }
        public string StudentId { get; set; }
        public Student Student { get; set; }
    }
}
