namespace CoursesShop.Data.Entities
{
    public sealed class Course
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public double ReviewsAverge { get; set; }
        public string ImageUrl { get; set; }
        public string TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public List<Receipt> Receipts { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
