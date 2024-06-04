using CoursesShop.Data.Entities;

namespace CoursesShop.Service.EntityServices.Interfaces
{
    public interface IReviewServices
    {
        public Task AddAsync(Review review);
        public Task UpdateAsync(Review review);
        public Task<List<Review>> GetAllByCourseIdAsync(string teacherId);
        public Task DeleteAsync(string Id);
        public bool IsIdExist(string Id);
        public bool IsStudentReview(string studentId);
        public bool IsReviewFromStudent(string reviewId, string studentId);
    }
}
