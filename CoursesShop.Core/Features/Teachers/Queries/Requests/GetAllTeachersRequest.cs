using CoursesShop.Core.Bases;
using CoursesShop.Data.Entities;
using MediatR;

namespace CoursesShop.Core.Features.Teachers.Queries.Requests
{
    public sealed class GetAllTeachersRequest : IRequest<Response<List<Teacher>>>
    {
    }
}
