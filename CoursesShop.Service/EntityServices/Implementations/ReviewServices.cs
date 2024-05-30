using CoursesShop.Data.Entities;
using CoursesShop.Infrastructure.Interfaces;
using CoursesShop.Service.EntityServices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoursesShop.Service.EntityServices.Implementations
{
    public sealed class ReviewServices(IReviewRepository reviewRepository) : IReviewServices
    {
        private readonly IReviewRepository _reviewRepository = reviewRepository;

        public async Task DeleteAsync(string Id)
        {
            var review = await _reviewRepository.GetByIdAsync(Id);
            await _reviewRepository.DeleteAsync(review);
        }

        public async Task<List<Review>> GetAllByCourseIdAsync(string courseId)
        {
            return await _reviewRepository.GetTableNoTracking()
                                          .Include(x => x.Student)
                                          .Where(x => x.CourseId == courseId)
                                          .Select(x => new Review { Student = new Student { FullName = x.Student.FullName }, Id = x.Id, Evalution = x.Evalution, Comment = x.Comment })
                                          .ToListAsync();
        }

        public bool IsIdExist(string Id)
        {
            return _reviewRepository.GetTableNoTracking().Any(x => x.Id == Id);
        }
    }
}
