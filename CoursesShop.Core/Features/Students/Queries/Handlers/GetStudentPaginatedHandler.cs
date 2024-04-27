﻿using AutoMapper;
using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.Students.Queries.Models;
using CoursesShop.Core.Wrapper;
using CoursesShop.Data.Entities;
using CoursesShop.Service.Abstracts;
using MediatR;

namespace CoursesShop.Core.Features.Students.Queries.Handlers
{
    public sealed class GetStudentPaginatedHandler(IStudentServices studentServices, IMapper mapper) : ResponseHandler, IRequestHandler<GetStudentPagintedRequest, PaginatedResult<Student>>
    {
        private readonly IStudentServices _studentServices = studentServices;
        private readonly IMapper _mapper = mapper;

        public async Task<PaginatedResult<Student>> Handle(GetStudentPagintedRequest request, CancellationToken cancellationToken)
        {
            var students = await _studentServices.GetAllAsQueryable().ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return students;
        }
    }
}