﻿using ClientApi.DTO;
using ClientApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientApi.Controllers
{

    [Route("api/products")]
    [ApiController]
    public class ProductsController : CustomControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public async Task<IActionResult> GetProducts(string size, string price, string internationalPrice, string brand, string color, string sellPrice, string rentPrice)
        {
            try
            {
                var result = await _productService.GetProducts(size, price, internationalPrice, brand, color, sellPrice, rentPrice);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ServerErrorResult();
            }
        }

        [HttpGet("catogery/{catogeryId}")]
        public async Task<IActionResult> GetProductsByCatogeryId(int catogeryId, string size, string price, string internationalSize, string brand, string color, string sellPrice, string rentPrice)
        {
            try
            {
                var result = await _productService.GetProductsByCatogeryId(catogeryId,  size,  price,  internationalSize,  brand,  color,  sellPrice,  rentPrice);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ServerErrorResult();
            }
        }


        [HttpGet("catogery-Gen/{catogeryId}")]
        public async Task<IActionResult> GetProductsByGenCatogeryId(int catogeryId, string size, string price, string internationalSize, string brand, string color, string sellPrice, string rentPrice)
        {
            try
            {
                var result = await _productService.GetProductsByGenCatogeryId(catogeryId, size, price, internationalSize, brand, color, sellPrice, rentPrice);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ServerErrorResult();
            }
        }

        [HttpGet("designer/{designerId}")]
        public async Task<IActionResult> GetProductsByDesignerId(int designerId, string size, string price, string internationalSize, string brand, string color, string sellPrice, string rentPrice)
        {
            try
            {
                var result = await _productService.GetProductsByDesignerId(designerId, size, price, internationalSize, brand, color, sellPrice, rentPrice);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ServerErrorResult();
            }
        }

        [HttpGet("type/{typeId}")]
        public async Task<IActionResult> GetProductsByTypeId(int typeId, string size, string price, string internationalSize, string brand, string color, string sellPrice, string rentPrice)
        {
            try
            {
                var result = await _productService.GetProductsByTypeId(typeId, size, price, internationalSize, brand, color, sellPrice, rentPrice);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ServerErrorResult();
            }
        }

        [HttpGet("edit/{editId}")]
        public async Task<IActionResult> GetProductsByEditId(int editId, string size, string price, string internationalSize, string brand, string color, string sellPrice, string rentPrice)
        {
            try
            {
                var result = await _productService.GetProductsByEditId(editId, size, price, internationalSize, brand, color, sellPrice, rentPrice);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ServerErrorResult();
            }
        }



        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProduct([FromRoute] int productId)
        {
            try
            {
                var result = await _productService.GetProduct(productId);
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

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeteleProduct([FromRoute] int productId)
        {
            try
            {
                var result = await _productService.DeteleProduct(productId);
                if (result == false)
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
        public async Task<IActionResult> SaveProduct([FromBody] ProductDto productDto)
        {
            try
            {
                var result = await _productService.SaveProduct(productDto);
                if (result == false)
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
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDto productDto)
        {
            try
            {
                var result = await _productService.UpdateProduct(productDto);
                if (result == false)
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
