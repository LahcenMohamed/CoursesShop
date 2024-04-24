﻿using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.Students.Queries.Results;
using CoursesShop.Data.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesShop.Core.Features.Students.Queries.Models
{
    public sealed class GetAllStudentsQuery : IRequest<Response<List<GetStudentResponse>>>
    {
    }
}
