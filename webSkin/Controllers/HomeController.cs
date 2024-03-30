using Microsoft.AspNetCore.Mvc;
using ParseTry.Main;
using System.Diagnostics;
using webSkin.Models;
using webSkins.Data;

namespace webSkin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISkinRepositroy skinRepositroy;

        public HomeController(ILogger<HomeController> logger, ISkinRepositroy skinRepositroy)
        {
            _logger = logger;
            this.skinRepositroy = skinRepositroy;
        }

        public async Task<IActionResult> IndexAsync(decimal minPrice, decimal maxPrice, string type, string exterior)
        {
            List<ResultItem> items = await skinRepositroy.GetAllSkinsAsync();
            items = items
                .Where(skin => skin.buff_sell_min_price >= minPrice && skin.buff_sell_min_price <= maxPrice)
                .Where(skin => skin.buff_exterior_localized_name == exterior)
                .Where(skin=> skin.buff_type_localized_name == type)
                .ToList();
            return View(items);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
