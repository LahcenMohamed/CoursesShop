using AutoMapper;
using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.Courses.Queries.Requests;
using CoursesShop.Core.Features.Courses.Queries.Results;
using CoursesShop.Core.Wrapper;
using CoursesShop.Service.EntityServices.Interfaces;
using MediatR;

namespace CoursesShop.Core.Features.Courses.Queries.Handlers
{
    public sealed class GetCoursesWithPaginationHandler(ICourseServices courseServices, IMapper mapper) : ResponseHandler, IRequestHandler<GetCoursesWithPaginationRequest, PaginatedResult<GetCourseResult>>
    {
        private readonly ICourseServices _courseServices = courseServices;
        private readonly IMapper _mapper = mapper;

        public async Task<PaginatedResult<GetCourseResult>> Handle(GetCoursesWithPaginationRequest request, CancellationToken cancellationToken)
        {
            if (request.Search is null)
            {
                var response = await _courseServices.GetAllAsQueryable().ToPaginatedListAsync(request.PageNumber, request.PageSize);
                var coursesMapping = _mapper.Map<PaginatedResult<GetCourseResult>>(response);
                return coursesMapping;
            }
            else
            {
                var response = await _courseServices.FillterAllAsQueryable(request.Search).ToPaginatedListAsync(request.PageNumber, request.PageSize);
                var coursesMapping = _mapper.Map<PaginatedResult<GetCourseResult>>(response);
                return coursesMapping;
            }
        }
    }
}
