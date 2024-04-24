﻿using AutoMapper;
using CoursesShop.Core.Features.Students.Queries.Results;
using CoursesShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesShop.Core.Mapping.Students
{
    public sealed partial class StudentProfile : Profile
    {
        public void GetStudentListMapping()
        {
            CreateMap<Student, GetStudentResponse>();
        }
    }
}
