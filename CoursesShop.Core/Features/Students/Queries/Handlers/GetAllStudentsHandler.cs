using CoursesShop.Core.Features.Students.Queries.Models;
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
    public sealed class GetAllStudentsHandler(IStudentServices studentServices) : IRequestHandler<GetAllStudentsQuery, List<Student>>
    {
        private readonly IStudentServices _studentServices = studentServices;
        public async Task<List<Student>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            return await _studentServices.GetAllAsync();
        }
    }
}
