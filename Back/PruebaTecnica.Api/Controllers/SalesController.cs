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
    public class SalesController : ControllerBase
    {
        private readonly ISalesService _salesService;

        public SalesController(ISalesService salesService)
        {
            _salesService = salesService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var service = await _salesService.Gets();
            var response = new ApiResponse<IEnumerable<Sales>>(service);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var service = await _salesService.Get(id);
            var response = new ApiResponse<Sales>(service);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Sales item)
        {
            await _salesService.Insert(item);
            var response = new ApiResponse<Sales>(item);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, Sales item)
        {
            item.Id = id;
            var result = await _salesService.Update(item);
            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _salesService.Delete(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}