using CoursesShop.Core.Bases;
using MediatR;

namespace CoursesShop.Core.Features.Receipts.Commands.Requests
{
    public sealed class AddReceiptRequest : IRequest<Response<string>>
    {
        public string CourseId { get; set; }
    }
}
