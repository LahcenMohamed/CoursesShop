using AutoMapper;
using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.Courses.Commands.Requests;
using CoursesShop.Data.Entities;
using CoursesShop.Service.EntityServices.Interfaces;
using CoursesShop.Service.UserServices.Interfaces;
using MediatR;

namespace CoursesShop.Core.Features.Courses.Commands.Handlers
{
    public class UpdateCourseHandler(ICourseServices courseServices,
                                     ICurrentUserService currentUserService,
                                     IMapper mapper) : ResponseHandler, IRequestHandler<UpdateCourseRequest, Response<string>>
    {
        private readonly ICourseServices _courseServices = courseServices;
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IMapper _mapper = mapper;

        public async Task<Response<string>> Handle(UpdateCourseRequest request, CancellationToken cancellationToken)
        {
            var course = _mapper.Map<Course>(request);
            var currentUser = await _currentUserService.GetUserAsync();
            course.TeacherId = currentUser.TypeId;
            await _courseServices.UpdateAsync(course, request.Image);

            return Success(course.Id);
        }
    }
}
