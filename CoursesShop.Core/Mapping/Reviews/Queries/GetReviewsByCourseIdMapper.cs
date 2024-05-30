using CoursesShop.Core.Features.Reviews.Queries.Results;
using CoursesShop.Data.Entities;

namespace CoursesShop.Core.Mapping.Reviews
{
    public partial class ReviewProfile
    {
        public void GetReviewsByCourseIdMapper()
        {
            CreateMap<Review, GetReviewResult>().ForMember(x => x.StudentName, s => s.MapFrom(r => r.Student.FullName));
        }
    }
}
