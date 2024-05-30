using CoursesShop.Data.Entities;

namespace CoursesShop.Service.EntityServices.Interfaces
{
    public interface IReviewServices
    {
        public Task<List<Review>> GetAllByCourseIdAsync(string teacherId);
        public Task DeleteAsync(string Id);
        public bool IsIdExist(string Id);
    }
}
