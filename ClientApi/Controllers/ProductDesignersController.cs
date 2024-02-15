using ClientApi.DTO;
using ClientApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ClientApi.Controllers
{
    [Route("api/product-designers")]
    [ApiController]
    public class ProductDesignersController : CustomControllerBase
    {
        private readonly IProductDesignerService _productDesignerService;

        public ProductDesignersController(IProductDesignerService productDesignerService)
        {
            _productDesignerService = productDesignerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductDesigners()
        {
            try
            {
                var result = await _productDesignerService.GetAllProductDesigners();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ServerErrorResult();
            }
        }

        [HttpGet("{productDesignerId}")]
        public async Task<IActionResult> GetProductDesigner([FromRoute] int productDesignerId)
        {
            try
            {
                var result = await _productDesignerService.GetProductDesigner(productDesignerId);
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

        [HttpDelete("{productDesignerId}")]
        public async Task<IActionResult> DeleteProductDesigner([FromRoute] int productDesignerId)
        {
            try
            {
                var result = await _productDesignerService.DeleteProductDesigner(productDesignerId);
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
        public async Task<IActionResult> SaveProductDesigner([FromBody] ProductDesignerDto productDto)
        {
            try
            {
                var result = await _productDesignerService.SaveProductDesigner(productDto);
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
        public async Task<IActionResult> UpdateProductDesigner([FromBody] ProductDesignerDto productDto)
        {
            try
            {
                var result = await _productDesignerService.UpdateProductDesigner(productDto);
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
