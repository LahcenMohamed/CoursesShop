using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.User.Commands.Requsets;
using CoursesShop.Service.Interfaces;
using MediatR;

namespace CoursesShop.Core.Features.User.Commands.Handlers
{
    public sealed class DeleteUserHandler(IUserServices userServices) : ResponseHandler, IRequestHandler<DeleteUserRequest, Response<string>>
    {
        private readonly IUserServices _userServices = userServices;

        public async Task<Response<string>> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var response = await _userServices.DeleteAsync(request.Id);
            if (response is "Succeeded")
            {
                return Deleted<string>();
            }
            return BadRequest<string>(response);
        }
    }
}
