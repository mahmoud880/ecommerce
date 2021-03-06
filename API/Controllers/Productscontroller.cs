using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Productscontroller : ControllerBase
    {
        private readonly IProductRepository _repo;

        public Productscontroller(IProductRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var product = await _repo.GetProductsAsync();
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _repo.GetProductByIdAsync(id);
            return Ok(product);
        }
        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductType()
        {
            return Ok(await _repo.GetProductTypeAsync());
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrand()
        {
            return Ok(await _repo.GetProductBrandAsync());
        }
    }
}