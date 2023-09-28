using AutoMapper;
using Discount.Grpc.Models;
using Discount.Grpc.Protos;

namespace Discount.Grpc.Mapper
{
    public sealed class DiscountProfileMapper : Profile
    {
        public DiscountProfileMapper()
        {
            CreateMap<Coupon, CouponModel>().ReverseMap();
        }
    }
}