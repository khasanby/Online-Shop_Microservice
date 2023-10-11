using Discount.Grpc.Protos;

namespace Basket.API.GrpcServices
{
    public sealed class DiscountGrpcService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _protoService;

        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient protoService)
        {
            _protoService = protoService;
        }

        public async Task<CouponModel> GetDiscountAsync(string productName)
        {
            var discountRequest = new GetDiscountRequest { ProductName = productName };

            return await _protoService.GetDiscountAsync(discountRequest);
        }
    }
}