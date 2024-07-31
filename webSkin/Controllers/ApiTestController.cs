using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webSkins.Data;

namespace webSkin.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ApiTestController : ControllerBase
    {
        private readonly ISkinRepositroy skinRepositroy;
        public ApiTestController(ISkinRepositroy skinRepositroy)
        {
            this.skinRepositroy = skinRepositroy;
        }
        [HttpGet("home")]
        public async Task<IActionResult> IndexAsync()
        {
            var resItem = await skinRepositroy.GetAllSkinsAsync();
            var item = resItem;
            return Ok(item);
        }
    }
}
