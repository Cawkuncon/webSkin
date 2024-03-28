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

        public async Task<IActionResult> IndexAsync()
        {
            List<ResultItem> items = (await skinRepositroy.GetAllSkinsAsync()).Take(10000).ToList();
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
