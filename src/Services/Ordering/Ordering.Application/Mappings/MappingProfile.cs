using AutoMapper;
using Ordering.Application.Features.Orders.Commands.CheckoutOrder;
using Ordering.Application.Features.Orders.Queries.GetOrdersList;
using Ordering.Domain.Entities;

namespace Ordering.Application.Mappings;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Order, OrdersVm>().ReverseMap();
        CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
        // CreateMap<Order, UpdateOrderCommand>().ReverseMap();
    }
}