
namespace CoursesShop.Data.Entities
{
    public sealed class Student
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<Receipt> Receipts { get; set; }
        public List<Review> Reviews { get; set; }

    }
}
