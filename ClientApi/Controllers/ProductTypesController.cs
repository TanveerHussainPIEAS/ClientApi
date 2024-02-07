using ClientApi.DTO;
using ClientApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientApi.Controllers
{

    [Route("api/product-types")]
    [ApiController]
    public class ProductTypesController : CustomControllerBase
    {
        private readonly IProductTpeService _productTypeService;
        public ProductTypesController(IProductTpeService productTypeService)
        {
            _productTypeService = productTypeService;
        }


        [HttpGet]
        public async Task<IActionResult> GetProductTypes()
        {
            try
            {
                var result = await _productTypeService.GetProductTypes();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ServerErrorResult();
            }
        }


        [HttpGet("{productTypeId}")]
        public async Task<IActionResult> GetProductType([FromRoute] int productTypeId)
        {
            try
            {
                var result = await _productTypeService.GetProductType(productTypeId);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ServerErrorResult();
            }
        }

        [HttpDelete("{productTypeId}")]
        public async Task<IActionResult> DeteleProductType([FromRoute] int productTypeId)
        {
            try
            {
                var result = await _productTypeService.DeteleProductType(productTypeId);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ServerErrorResult();
            }
        }


        [HttpPost]
        public async Task<IActionResult> SaveProductType([FromBody] ProductTypeDto productDto)
        {
            try
            {
                var result = await _productTypeService.SaveProductType(productDto);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ServerErrorResult();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductType([FromBody] ProductTypeDto productDto)
        {
            try
            {
                var result = await _productTypeService.UpdateProductType(productDto);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ServerErrorResult();
            }
        }
    }
}
