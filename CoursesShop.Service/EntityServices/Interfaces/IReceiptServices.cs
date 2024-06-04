using CoursesShop.Data.Entities;

namespace CoursesShop.Service.EntityServices.Interfaces
{
    public interface IReceiptServices
    {
        public Task<string> AddAsync(Receipt receipt, string studentEmail);
        public bool IsStudentByThisCourse(string courseId, string studentId);
    }
}
