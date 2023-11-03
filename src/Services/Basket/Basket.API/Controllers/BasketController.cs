using System.Net;
using AutoMapper;
using Basket.API.Entities;
using Basket.API.GrpcServices;
using Basket.API.Repositories;
using EventBus.Messages.Events;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public sealed class BasketController : ControllerBase
{
    private readonly DiscountGrpcService _grpcService;
    private readonly IBasketRepository _repository;
    private readonly IMapper _mapper;
    private readonly IPublishEndpoint _publishEndpoint;

    public BasketController(IBasketRepository repository,
                            DiscountGrpcService grpcService,
                            IMapper mapper,
                            IPublishEndpoint publishEndpoint)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _grpcService = grpcService;
        _mapper = mapper;
        _publishEndpoint = publishEndpoint;
    }

    [HttpGet("{userName}", Name = "GetBasket")]
    [ProducesResponseType(typeof(ShoppingCartDb), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ShoppingCartDb>> GetBasketAsync(string userName)
    {
        var basket = await _repository.GetBasketAsync(userName);
        return Ok(basket ?? new ShoppingCartDb(userName));
    }

    [HttpPost]
    [ProducesResponseType(typeof(ShoppingCartDb), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ShoppingCartDb>> UpdateBasketAsync([FromBody] ShoppingCartDb basket)
    {
        // foreach (var item in basket.Items)
        // {
        //     var couponInfo = await _grpcService.GetDiscountAsync(item.ProductName);
        //     item.Price = couponInfo.Amount;
        // }

        return Ok(await _repository.UpdateBasketAsync(basket));
    }

    [HttpDelete("{userName}", Name = "DeleteBasket")]
    [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeleteBasketAsync(string userName)
    {
        await _repository.DeleteBasketAsync(userName);
        return Ok();
    }
    
    [HttpPost]
    [Route("[action]")]
    [ProducesResponseType((int)HttpStatusCode.Accepted)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CheckoutAsync([FromBody] BasketCheckout basketCheckout)
    {
        var basket = await _repository.GetBasketAsync(basketCheckout.UserName);
        if(basket == null)
            return BadRequest();
        
        var eventMessage = _mapper.Map<BasketCheckoutEvent>(basketCheckout);
        eventMessage.TotalPrice = basket.TotalPrice;
        await _publishEndpoint.Publish(eventMessage);
        await _repository.DeleteBasketAsync(basket.UserName);
        
        return Accepted();
    }
}