﻿using ElasticSearchProduct.API.Dto;
using ElasticSearchProduct.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElasticSearchProduct.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(ProductCreateDTO productCreateDTO)
        {
            var response = await _productService.SaveAsync(productCreateDTO);
            return CreateActionResult(response);
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await _productService.GetAllAsync();
            return CreateActionResult(response);
        }

        [HttpGet("GetByProductId/{productId}")]
        public async Task<IActionResult> GetAllProducts(string productId)
        {
            var response = await _productService.GetByIdAsync(productId);
            return CreateActionResult(response);
        }

        [HttpPut("ProductUpdate")]
        public async Task<IActionResult> ProductUpdate(ProductUpdateDTO productUpdateDTO)
        {
            var response = await _productService.UpdateAsync(productUpdateDTO);
            return CreateActionResult(response);
        }

        [HttpDelete("ProductDelete/{productId}")]
        public async Task<IActionResult> ProductUpdate(string productId)
        {
            var response = await _productService.DeleteAsync(productId);
            return CreateActionResult(response);
        }
    }
}
