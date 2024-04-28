using AutoMapper;
using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.Students.Queries.Models;
using CoursesShop.Core.Features.Students.Queries.Results;
using CoursesShop.Service.Abstracts;
using MediatR;

namespace CoursesShop.Core.Features.Students.Queries.Handlers
{
    public sealed class GetAllStudentsHandler(IStudentServices studentServices, IMapper mapper) : ResponseHandler, IRequestHandler<GetAllStudentsRequest, Response<List<GetStudentResponse>>>
    {
        private readonly IStudentServices _studentServices = studentServices;
        private readonly IMapper _mapper = mapper;
        public async Task<Response<List<GetStudentResponse>>> Handle(GetAllStudentsRequest request, CancellationToken cancellationToken)
        {
            var students = await _studentServices.GetAllAsync();
            var studentsMapper = _mapper.Map<List<GetStudentResponse>>(students);
            return Success(studentsMapper, new { Count = studentsMapper.Count });
        }
    }
}
