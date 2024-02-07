using ClientApi.DTO;
using ClientApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ClientApi.Controllers
{
    [Route("api/product-categories")]
    [ApiController]
    public class ProductCategoriesController : CustomControllerBase
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoriesController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductCategories()
        {
            try
            {
                var result = await _productCategoryService.GetProductCategories();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ServerErrorResult();
            }
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetProductCategory([FromRoute] int categoryId)
        {
            try
            {
                var result = await _productCategoryService.GetProductCategory(categoryId);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ServerErrorResult();
            }
        }

        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> DeleteProductCategory([FromRoute] int categoryId)
        {
            try
            {
                var result = await _productCategoryService.DeleteProductCategory(categoryId);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ServerErrorResult();
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveProductCategory([FromBody] ProductCategoryDto productCategoryDto)
        {
            try
            {
                var result = await _productCategoryService.SaveProductCategory(productCategoryDto);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ServerErrorResult();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductCategory([FromBody] ProductCategoryDto productCategoryDto)
        {
            try
            {
                var result = await _productCategoryService.UpdateProductCategory(productCategoryDto);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ServerErrorResult();
            }
        }
    }
}
