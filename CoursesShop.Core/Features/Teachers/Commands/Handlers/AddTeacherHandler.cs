using AutoMapper;
using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.Teachers.Commands.Requests;
using CoursesShop.Data.Entities;
using CoursesShop.Service.EntityServices.Interfaces;
using MediatR;

namespace CoursesShop.Core.Features.Teachers.Commands.Handlers
{
    public sealed class AddTeacherHandler(ITeacherServices teacherServices, IMapper mapper) : ResponseHandler, IRequestHandler<AddTeacherRequest, Response<string>>
    {
        private readonly ITeacherServices _teacherServices = teacherServices;
        private readonly IMapper _mapper = mapper;
        public async Task<Response<string>> Handle(AddTeacherRequest request, CancellationToken cancellationToken)
        {
            Teacher teacher = _mapper.Map<Teacher>(request);
            await _teacherServices.AddAsync(teacher, request.image);
            return Created(teacher.Id);
        }
    }
}
