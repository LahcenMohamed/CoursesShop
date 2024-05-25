using CoursesShop.Core.Bases;
using MediatR;

namespace CoursesShop.Core.Features.Authentication.Queries.Requests
{
    public sealed class ConfirmEmailRequest : IRequest<Response<string>>
    {
        public string userId { get; set; }
        public string code { get; set; }
    }
}
