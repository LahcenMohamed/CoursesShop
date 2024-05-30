﻿using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.Reviews.Commands.Requests;
using CoursesShop.Service.EntityServices.Interfaces;
using MediatR;

namespace CoursesShop.Core.Features.Reviews.Commands.Handlers
{
    public sealed class DeleteReviewHandler(IReviewServices reviewServices) : ResponseHandler, IRequestHandler<DeleteReviewRequest, Response<string>>
    {
        private readonly IReviewServices _reviewServices = reviewServices;

        public async Task<Response<string>> Handle(DeleteReviewRequest request, CancellationToken cancellationToken)
        {
            await _reviewServices.DeleteAsync(request.Id);
            return Deleted<string>();
        }
    }
}
