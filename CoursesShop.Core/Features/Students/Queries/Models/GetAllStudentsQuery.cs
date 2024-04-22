using CoursesShop.Data.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesShop.Core.Features.Students.Queries.Models
{
    public sealed class GetAllStudentsQuery : IRequest<List<Student>>
    {
    }
}
