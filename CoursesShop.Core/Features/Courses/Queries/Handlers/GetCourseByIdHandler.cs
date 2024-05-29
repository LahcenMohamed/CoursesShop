using AutoMapper;
using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.Courses.Queries.Requests;
using CoursesShop.Core.Features.Courses.Queries.Results;
using CoursesShop.Service.EntityServices.Interfaces;
using MediatR;

namespace CoursesShop.Core.Features.Courses.Queries.Handlers
{
    public sealed class GetCourseByIdHandler(ICourseServices courseServices, IMapper mapper) : ResponseHandler, IRequestHandler<GetCourseByIdRequest, Response<GetCourseResult>>
    {
        private readonly ICourseServices _courseServices = courseServices;
        private readonly IMapper _mapper = mapper;

        public async Task<Response<GetCourseResult>> Handle(GetCourseByIdRequest request, CancellationToken cancellationToken)
        {
            var course = _courseServices.GetById(request.Id);
            var courseMapping = _mapper.Map<GetCourseResult>(course);
            return Success(courseMapping);
        }
    }
}
