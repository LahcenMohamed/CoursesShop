using CoursesShop.Core.Features.Students.Queries.Models;
using CoursesShop.Core.Wrapper;
using CoursesShop.Data.Entities;
using CoursesShop.Service.EntityServices.Interfaces;
using MediatR;

namespace CoursesShop.Core.Features.Students.Queries.Handlers
{
    public sealed class GetStudentPaginatedHandler(IStudentServices studentServices) : IRequestHandler<GetStudentPagintedRequest, PaginatedResult<Student>>
    {
        private readonly IStudentServices _studentServices = studentServices;

        public async Task<PaginatedResult<Student>> Handle(GetStudentPagintedRequest request, CancellationToken cancellationToken)
        {
            if (request.Search is null)
            {
                return await _studentServices.GetAllAsQueryable()
                                             .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            }
            return await _studentServices.FillterAsQueryable(request.Search)
                                         .ToPaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
