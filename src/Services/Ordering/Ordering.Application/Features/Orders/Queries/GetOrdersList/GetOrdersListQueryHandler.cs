﻿using AutoMapper;
using MediatR;
using Ordering.Application.Contracts.Repositories;

namespace Ordering.Application.Features.Orders.Queries.GetOrdersList;

public sealed class GetOrdersListQueryHandler : IRequestHandler<GetOrdersListQuery, List<OrdersVm>>
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;

    public GetOrdersListQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<List<OrdersVm>> Handle(GetOrdersListQuery request,
        CancellationToken cancellationToken)
    {
        var orderList = await _orderRepository.GetOrdersByUsernameAsync(request.UserName);
        return _mapper.Map<List<OrdersVm>>(orderList);
    }
}