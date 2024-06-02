using AutoMapper;
using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.Courses.Queries.Requests;
using CoursesShop.Core.Features.Courses.Queries.Results;
using CoursesShop.Service.EntityServices.Interfaces;
using CoursesShop.Service.UserServices.Interfaces;
using MediatR;

namespace CoursesShop.Core.Features.Courses.Queries.Handlers
{
    public sealed class GetCoursesByTeacherIdHandler(ICourseServices courseServices, ICurrentUserService currentUserService, IMapper mapper) : ResponseHandler, IRequestHandler<GetCoursesByTeacherIdRequest, Response<List<GetCourseResult>>>
    {
        private readonly ICourseServices _courseServices = courseServices;
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IMapper _mapper = mapper;

        public async Task<Response<List<GetCourseResult>>> Handle(GetCoursesByTeacherIdRequest request, CancellationToken cancellationToken)
        {
            string teacherId = _currentUserService.GetTypeId();
            var response = await _courseServices.GetByTeacherIdAsync(teacherId);
            var coursesMapping = _mapper.Map<List<GetCourseResult>>(response);
            return Success(coursesMapping);
        }
    }
}