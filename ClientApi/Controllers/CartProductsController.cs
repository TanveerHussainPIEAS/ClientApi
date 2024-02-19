using ClientApi.DTO;
using ClientApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ClientApi.Controllers
{
    [Route("api/cart-products")]
    [ApiController]
    public class CartProductsController : CustomControllerBase
    {
        private readonly ICartProductService _cartProductService;

        public CartProductsController(ICartProductService cartProductService)
        {
            _cartProductService = cartProductService;
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetCartProducts(int userId)
        {
            try
            {
                var result = await _cartProductService.GetCartProducts(userId);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ServerErrorResult();
            }
        }

        [HttpDelete("{cartProductId}")]
        public async Task<IActionResult> DeleteCartProduct([FromRoute] int cartProductId)
        {
            try
            {
                var result = await _cartProductService.DeleteCartProduct(cartProductId);
                if (!result)
                {
                    return ServerErrorResult();
                }
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ServerErrorResult();
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveCartProduct([FromBody] List<CartProductDto> cartProductDtos)
        {
            try
            {
                var result = await _cartProductService.SaveCartProduct(cartProductDtos);
                if (!result)
                {
                    return ServerErrorResult();
                }
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ServerErrorResult();
            }
        }
        
    }
}
