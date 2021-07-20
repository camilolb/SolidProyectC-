using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Api.Responses;
using PruebaTecnica.Core.Entities;
using PruebaTecnica.Core.Interfaces;

namespace PruebaTecnica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _userService;
        private readonly IJwtService _jwtService;


        public SecurityController(ISecurityService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpPost("{login}")]
        public async Task<IActionResult> Login(string userName, string password)
        {

            try
            {
                var service = await _userService.Get(userName, password);
                service.Token = _jwtService.Generate(service.Id);

                Response.Cookies.Append("jwt", service.Token, new CookieOptions
                {
                    HttpOnly = true
                });

                var response = new ApiResponse<Security>(service);
                return Ok(response);
            }
            catch (System.Exception)
            {
                return Unauthorized();
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var service = await _userService.Get(id);
            var response = new ApiResponse<Security>(service);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Security item)
        {
            await _userService.Insert(item);
            var response = new ApiResponse<Security>(item);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, Security item)
        {
            item.Id = id;
            var result = await _userService.Update(item);
            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.Delete(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }


        [HttpPost]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            var response = new ApiResponse<bool>(true);
            return Ok(response);
        }


    }
}