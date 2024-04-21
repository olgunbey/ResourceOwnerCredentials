using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ResourceOwnerCredentials.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //[HttpGet]
        //[Authorize(AuthenticationSchemes = "JwtBearerRead")]
        //public IActionResult ReadApi()
        //{
        //    return Ok("Read api çalıştı");
        //}
        //[HttpGet]
        //[Authorize(AuthenticationSchemes = "JwtBearerWrite")]
        //public IActionResult WriteApi()
        //{
        //    return Ok("Write api çalıştı");
        //}
        //[HttpGet]
        //[Authorize(AuthenticationSchemes = "JwtBearerAdmin")]
        //public IActionResult AdminApi()
        //{
        //    return Ok("Admin api çalıştı");
        //}
        [HttpGet]
        [Authorize(Policy ="policy1")]
        public IActionResult PolicyReadApi()
        {
            return Ok();
        }
    }
}
