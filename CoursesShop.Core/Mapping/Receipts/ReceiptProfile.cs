using AutoMapper;

namespace CoursesShop.Core.Mapping.Receipts
{
    public partial class ReceiptProfile : Profile
    {
        public ReceiptProfile()
        {
            AddReceiptMapper();
        }
    }
}
