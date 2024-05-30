using AutoMapper;

namespace CoursesShop.Core.Mapping.Reviews
{
    public partial class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            GetReviewsByCourseIdMapper();
        }
    }
}
