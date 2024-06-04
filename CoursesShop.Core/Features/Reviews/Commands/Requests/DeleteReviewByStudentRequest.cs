﻿using CoursesShop.Core.Bases;
using MediatR;

namespace CoursesShop.Core.Features.Reviews.Commands.Requests
{
    public sealed class DeleteReviewByStudentRequest : IRequest<Response<string>>
    {
        public required string Id { get; set; }
    }
}
