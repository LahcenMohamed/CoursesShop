using AutoMapper;
using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.Students.Queries.Models;
using CoursesShop.Core.Features.Students.Queries.Results;
using CoursesShop.Data.Entities;
using CoursesShop.Service.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesShop.Core.Features.Students.Queries.Handlers
{
    public sealed class GetAllStudentsHandler(IStudentServices studentServices,IMapper mapper) :ResponseHandler , IRequestHandler<GetAllStudentsQuery,Response<List<GetStudentResponse>>>
    {
        private readonly IStudentServices _studentServices = studentServices;
        private readonly IMapper _mapper = mapper; 
        public async Task<Response<List<GetStudentResponse>>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentServices.GetAllAsync();
            var studentsMapper = _mapper.Map<List<GetStudentResponse>>(students);
            return Success(studentsMapper);
        }
    }
}
