﻿using MediatR;

namespace Ordering.Application.Features.Orders.Queries.GetOrdersList;

public sealed class GetOrdersListQuery : IRequest<List<OrdersVm>>
{
    public GetOrdersListQuery(string userName)
    {
        UserName = userName;
    }

    public string UserName { get; set; }
}