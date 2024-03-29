﻿using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using MassTransit.Mediator;
using Ordering.Application.Features.Orders.Commands.CheckoutOrder;

namespace Ordering.API.EventBusConsumer;

public sealed class BasketCheckoutConsumer : IConsumer<BasketCheckoutEvent>
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ILogger<BasketCheckoutConsumer> _logger;

    public BasketCheckoutConsumer(IMediator mediator,
                                  IMapper mapper,
                                  ILogger<BasketCheckoutConsumer> logger)
    {
        _mediator = mediator;
        _mapper = mapper;
        _logger = logger;
    }
    
    /// <summary>
    /// Consumes BasketCheckoutEvent and sends CheckoutOrderCommand to the MediatR pipeline
    /// </summary>
    public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
    {
        var command = _mapper.Map<CheckoutOrderCommand>(context.Message);
        await _mediator.Send(command);
        
        _logger.LogInformation("BasketCheckoutEvent consumed successfully.");
    }
}