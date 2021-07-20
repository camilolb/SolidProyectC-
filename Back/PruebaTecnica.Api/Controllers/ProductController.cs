using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Api.Responses;
using PruebaTecnica.Core.Entities;
using PruebaTecnica.Core.Interfaces;

namespace PruebaTecnica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var service = await _productService.Gets();
            var response = new ApiResponse<IEnumerable<Product>>(service);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var service = await _productService.GetCode(id);
            var response = new ApiResponse<Product>(service);
            return Ok(response);
        }



        [HttpPost]
        public async Task<IActionResult> Post(Product item)
        {
            await _productService.Insert(item);
            var response = new ApiResponse<Product>(item);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, Product item)
        {
            item.Id = id;
            var result = await _productService.Update(item);
            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }


    }
}