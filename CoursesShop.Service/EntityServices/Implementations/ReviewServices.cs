using CoursesShop.Data.Entities;
using CoursesShop.Infrastructure.Interfaces;
using CoursesShop.Service.EntityServices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoursesShop.Service.EntityServices.Implementations
{
    public sealed class ReviewServices(IReviewRepository reviewRepository, ICourseServices courseServices) : IReviewServices
    {
        private readonly IReviewRepository _reviewRepository = reviewRepository;
        private readonly ICourseServices _courseServices = courseServices;

        public async Task AddAsync(Review review)
        {
            await _reviewRepository.AddAsync(review);
            await _courseServices.UpdateRating(review.CourseId, review.Evalution, UpdateRatingType.Add);
        }

        public async Task UpdateAsync(Review review)
        {
            var oldReview = await _reviewRepository.GetByIdAsync(review.Id);

            var oldEvaluation = oldReview.Evalution;

            oldReview.Evalution = review.Evalution;
            oldReview.Comment = review.Comment;
            oldReview.StudentId = review.StudentId;
            oldReview.CourseId = review.CourseId;

            await _reviewRepository.UpdateAsync(oldReview);
            await _courseServices.UpdateRating(review.CourseId, review.Evalution - oldEvaluation, UpdateRatingType.Update);
        }

        public async Task DeleteAsync(string Id)
        {
            var review = await _reviewRepository.GetByIdAsync(Id);
            await _reviewRepository.DeleteAsync(review);
            await _courseServices.UpdateRating(review.CourseId, review.Evalution, UpdateRatingType.Delete);
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

        public bool IsStudentReview(string studentId)
        {
            return _reviewRepository.GetTableNoTracking().Any(x => x.StudentId == studentId);
        }

        public bool IsReviewFromStudent(string reviewId, string studentId)
        {
            return _reviewRepository.GetTableNoTracking().Any(x => x.StudentId == studentId && x.Id == reviewId);
        }


    }
}
