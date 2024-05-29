using CoursesShop.Core.Features.Teachers.Queries.Requests;
using CoursesShop.Core.Wrapper;
using CoursesShop.Data.Entities;
using CoursesShop.Service.EntityServices.Interfaces;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace CoursesShop.Core.Features.Teachers.Queries.Handlers
{
    public sealed class GetTeachersWithPaginationHandler(ITeacherServices teacherServices) : IRequestHandler<GetTeachersWithPaginationRequest, PaginatedResult<Teacher>>
    {
        private readonly ITeacherServices _teacherServices = teacherServices;

        public async Task<PaginatedResult<Teacher>> Handle(GetTeachersWithPaginationRequest request, CancellationToken cancellationToken)
        {
            if (request.Search.IsNullOrEmpty())
            {
                return await _teacherServices.GetAllAsQueryable().ToPaginatedListAsync(request.PageNumber, request.PageSize);
            }
            return await _teacherServices.FillterAllAsQueryable(request.Search).ToPaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
