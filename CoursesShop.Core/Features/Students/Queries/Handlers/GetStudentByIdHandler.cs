using AutoMapper;
using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.Students.Queries.Models;
using CoursesShop.Core.Features.Students.Queries.Results;
using CoursesShop.Service.EntityServices.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesShop.Core.Features.Students.Queries.Handlers
{
    public sealed class GetStudentByIdHandler(IStudentServices studentServices,IMapper mapper) : ResponseHandler, IRequestHandler<GetStudentByIdRequest, Response<GetStudentResponse>>
    {
        private readonly IStudentServices _studentServices = studentServices;
        private readonly IMapper _mapper = mapper;

        public async Task<Response<GetStudentResponse>> Handle(GetStudentByIdRequest request, CancellationToken cancellationToken)
        {
            var student = await _studentServices.GetByIdAsync(request.Id);
            if (student is null)
                return NotFound<GetStudentResponse>($"did not found any student with Id {request.Id}");
            var studentMapper = _mapper.Map<GetStudentResponse>(student);
            return Success(studentMapper);
        }
    }
}
