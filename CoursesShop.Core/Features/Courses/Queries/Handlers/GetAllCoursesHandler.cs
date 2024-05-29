using AutoMapper;
using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.Courses.Queries.Requests;
using CoursesShop.Core.Features.Courses.Queries.Results;
using CoursesShop.Service.EntityServices.Interfaces;
using MediatR;

namespace CoursesShop.Core.Features.Courses.Queries.Handlers
{
    public sealed class GetAllCoursesHandler(ICourseServices courseServices, IMapper mapper) : ResponseHandler, IRequestHandler<GetAllCoursesRequest, Response<List<GetCourseResult>>>
    {
        private readonly ICourseServices _courseServices = courseServices;
        private readonly IMapper _mapper = mapper;

        public async Task<Response<List<GetCourseResult>>> Handle(GetAllCoursesRequest request, CancellationToken cancellationToken)
        {
            var response = await _courseServices.GetAllAsync();
            var coursesMapping = _mapper.Map<List<GetCourseResult>>(response);
            return Success(coursesMapping);
        }
    }
}
