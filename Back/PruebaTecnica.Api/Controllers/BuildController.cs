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
    public class BuildController : ControllerBase
    {
        private readonly IBuildService _BuildService;

        public BuildController(IBuildService BuildService)
        {
            _BuildService = BuildService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var service =  _BuildService.Gets();
            var response = new ApiResponse<IEnumerable<Build>>(service);
            return Ok(response);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var service = await _BuildService.Get(id);
            var response = new ApiResponse<Build>(service);
            return Ok(response);
        }



        [HttpPost]
        public async Task<IActionResult> Post(Build item)
        {
            await _BuildService.Insert(item);
            var response = new ApiResponse<Build>(item);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Put(int id, Build item)
        {
            item.Id = id;
            _BuildService.Update(item);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }


    }
}