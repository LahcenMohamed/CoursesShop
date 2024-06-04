using CoursesShop.Core.Features.Receipts.Commands.Requests;
using CoursesShop.Data.Entities;

namespace CoursesShop.Core.Mapping.Receipts
{
    public partial class ReceiptProfile
    {
        public void AddReceiptMapper()
        {
            CreateMap<AddReceiptRequest, Receipt>();
        }
    }
}
