using ClientApi.DTO;
using ClientApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ClientApi.Controllers
{
    [Route("api/product-edits")]
    [ApiController]
    public class ProductEditsController : CustomControllerBase
    {
        private readonly IProductEditService _productEditService;

        public ProductEditsController(IProductEditService productEditService)
        {
            _productEditService = productEditService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductEdits()
        {
            try
            {
                var result = await _productEditService.GetProductEdits();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ServerErrorResult();
            }
        }

        [HttpGet("{productEditId}")]
        public async Task<IActionResult> GetProductEdit([FromRoute] int productEditId)
        {
            try
            {
                var result = await _productEditService.GetProductEdit(productEditId);
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

        [HttpDelete("{productEditId}")]
        public async Task<IActionResult> DeleteProductEdit([FromRoute] int productEditId)
        {
            try
            {
                var result = await _productEditService.DeleteProductEdit(productEditId);
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
        public async Task<IActionResult> SaveProductEdit([FromBody] ProductEditDto productDto)
        {
            try
            {
                var result = await _productEditService.SaveProductEdit(productDto);
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
        public async Task<IActionResult> UpdateProductEdit([FromBody] ProductEditDto productDto)
        {
            try
            {
                var result = await _productEditService.UpdateProductEdit(productDto);
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
