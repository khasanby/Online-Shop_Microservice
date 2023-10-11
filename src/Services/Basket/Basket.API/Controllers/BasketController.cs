using Basket.API.Entities;
using Basket.API.GrpcServices;
using Basket.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public sealed class BasketController : ControllerBase
    {
        private readonly IBasketRepository _repository;
        private readonly DiscountGrpcService _grpcService;

        public BasketController(IBasketRepository repository, DiscountGrpcService grpcService)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _grpcService = grpcService;
        }

        [HttpGet("{userName}", Name = "GetBasket")]
        [ProducesResponseType(typeof(ShoppingCartDb), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCartDb>> GetBasket(string userName)
        {
            var basket = await _repository.GetBasketAsync(userName);
            return Ok(basket ?? new ShoppingCartDb(userName));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCartDb), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCartDb>> UpdateBasket([FromBody] ShoppingCartDb basket)
        {
            foreach (var item in basket.Items)
            {
                var couponInfo = await _grpcService.GetDiscountAsync(item.ProductName);
                item.Price = couponInfo.Amount;

            }

            return Ok(await _repository.UpdateBasketAsync(basket));
        }

        [HttpDelete("{userName}", Name = "DeleteBasket")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBasket(string userName)
        {
            await _repository.DeleteBasketAsync(userName);
            return Ok();
        }
    }
}
