using ClientApi.DTO;
using ClientApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ClientApi.Controllers
{
    [Route("api/product-gen-categories")]
    [ApiController]
    public class ProductGenCategoriesController : CustomControllerBase
    {
        private readonly IProductGenCategoryService _productGenCategoryService;

        public ProductGenCategoriesController(IProductGenCategoryService productGenCategoryService)
        {
            _productGenCategoryService = productGenCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductGenCategories()
        {
            try
            {
                var result = await _productGenCategoryService.GetProductGenCategories();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ServerErrorResult();
            }
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetProductGenCategory([FromRoute] int categoryId)
        {
            try
            {
                var result = await _productGenCategoryService.GetProductGenCategory(categoryId);
                if (result == null)
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

        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> DeleteProductGenCategory([FromRoute] int categoryId)
        {
            try
            {
                var result = await _productGenCategoryService.DeleteProductGenCategory(categoryId);
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
        public async Task<IActionResult> SaveProductGenCategory([FromBody] ProductGenCategoryDto productGenCategoryDto)
        {
            try
            {
                var result = await _productGenCategoryService.SaveProductGenCategory(productGenCategoryDto);
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

        [HttpPut]
        public async Task<IActionResult> UpdateProductGenCategory([FromBody] ProductGenCategoryDto productGenCategoryDto)
        {
            try
            {
                var result = await _productGenCategoryService.UpdateProductGenCategory(productGenCategoryDto);
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
