namespace CoursesShop.Core.Features.Reviews.Queries.Results
{
    public sealed class GetReviewResult
    {
        public string Id { get; set; }
        public double Evalution { get; set; }
        public string? Comment { get; set; }
        public string StudentName { get; set; }
    }
}
