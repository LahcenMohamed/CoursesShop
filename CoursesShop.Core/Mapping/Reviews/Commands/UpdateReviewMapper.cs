using CoursesShop.Core.Features.Reviews.Commands.Requests;
using CoursesShop.Data.Entities;

namespace CoursesShop.Core.Mapping.Reviews
{
    public partial class ReviewProfile
    {
        public void UpdateReviewMapper()
        {
            CreateMap<UpdateReviewRequest, Review>();
        }
    }
}
