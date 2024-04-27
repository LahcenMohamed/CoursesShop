using AutoMapper;
using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.Students.Commands.Models;
using CoursesShop.Data.Entities;
using CoursesShop.Service.Abstracts;
using MediatR;

namespace CoursesShop.Core.Features.Students.Commands.Handlers
{
    public sealed class AddStudentHandler(IStudentServices studentServices, IMapper mapper) : ResponseHandler, IRequestHandler<AddStudentRequest, Response<string>>
    {
        private readonly IStudentServices _studentServices = studentServices;
        private readonly IMapper _mapper = mapper;
        public async Task<Response<string>> Handle(AddStudentRequest request, CancellationToken cancellationToken)
        {
            var studentMappeing = _mapper.Map<Student>(request);
            await _studentServices.AddStudent(studentMappeing);

            return Created("studentMappeing");
        }
    }
}
