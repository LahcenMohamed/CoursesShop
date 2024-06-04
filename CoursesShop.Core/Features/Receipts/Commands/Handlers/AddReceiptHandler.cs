using AutoMapper;
using CoursesShop.Core.Bases;
using CoursesShop.Core.Features.Receipts.Commands.Requests;
using CoursesShop.Data.Entities;
using CoursesShop.Service.EntityServices.Interfaces;
using CoursesShop.Service.UserServices.Interfaces;
using MediatR;

namespace CoursesShop.Core.Features.Receipts.Commands.Handlers
{
    public sealed class AddReceiptHandler(ICurrentUserService currentUserService, IReceiptServices receiptServices, IMapper mapper)
        : ResponseHandler, IRequestHandler<AddReceiptRequest, Response<string>>
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IReceiptServices _receiptServices = receiptServices;
        private readonly IMapper _mapper = mapper;

        public async Task<Response<string>> Handle(AddReceiptRequest request, CancellationToken cancellationToken)
        {
            var student = await _currentUserService.GetUserAsync();
            var receipt = _mapper.Map<Receipt>(request);
            receipt.StudentId = student.TypeId;
            var receiptId = await _receiptServices.AddAsync(receipt, student.Email);
            return Created(receiptId);
        }
    }
}
