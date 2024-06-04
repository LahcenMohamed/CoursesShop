using CoursesShop.Data.Entities;
using CoursesShop.Infrastructure.Interfaces;
using CoursesShop.Service.EntityServices.Interfaces;
using CoursesShop.Service.UserServices.Interfaces;

namespace CoursesShop.Service.EntityServices.Implementations
{
    public sealed class ReceiptServices(IReceiptRepository receiptRepository,
                                        IEmailServices emailServices,
                                        ITeacherServices teacherServices,
                                        ICourseServices courseServices) : IReceiptServices
    {
        private readonly IReceiptRepository _receiptRepository = receiptRepository;
        private readonly IEmailServices _emailServices = emailServices;
        private readonly ITeacherServices _teacherServices = teacherServices;
        private readonly ICourseServices _courseServices = courseServices;

        public async Task<string> AddAsync(Receipt receipt, string studentEmail)
        {
            var course = _courseServices.GetById(receipt.CourseId);
            var teacher = _teacherServices.GetById(course.TeacherId);

            receipt.Price = course.Price;
            await _receiptRepository.AddAsync(receipt);
            await _emailServices.SendEmailAsync(teacher.Email, $"student {studentEmail} bought your course: {course.Title}", "Bought course");
            await _emailServices.SendEmailAsync(studentEmail, $"you just bought course: {course.Title} from {teacher.FullName}", "Bought course");
            return receipt.Id;
        }

        public bool IsStudentByThisCourse(string courseId, string studentId)
        {
            return _receiptRepository.GetTableNoTracking().Any(x => x.CourseId == courseId && x.StudentId == studentId);
        }
    }
}
