using ClientApi.DTO;
using ClientApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ClientApi.Controllers
{
    [Route("api/wishlist-products")]
    [ApiController]
    public class WishListProductsController : CustomControllerBase
    {
        private readonly IWishListProductService _wishListProductService;

        public WishListProductsController(IWishListProductService wishListProductService)
        {
            _wishListProductService = wishListProductService;
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetWishListProducts(int userId)
        {
            try
            {
                var result = await _wishListProductService.GetWishListProducts(userId);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ServerErrorResult();
            }
        }


        [HttpDelete("{wishListProductId}")]
        public async Task<IActionResult> DeleteWishListProduct([FromRoute] int wishListProductId)
        {
            try
            {
                var result = await _wishListProductService.DeleteWishListProduct(wishListProductId);
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
        public async Task<IActionResult> SaveWishListProduct([FromBody] WishListProductDto wishListProductDtos)
        {
            try
            {
                var result = await _wishListProductService.SaveWishListProduct(wishListProductDtos);
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
