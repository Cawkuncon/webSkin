using Microsoft.AspNetCore.Mvc;
using ParseTry.Main;
using System.Diagnostics;
using webSkin.HelperClasses;
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
            var hashSetType = new HashSet<string>();
            var hashSetExtertior = new HashSet<string>();
            List<ResultItem> items = await skinRepositroy.GetAllSkinsAsync();
            ViewBag.Skins = items;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(SearchingClass argsClass)
        {
            List<ResultItem> items = await skinRepositroy.GetAllSkinsAsync();
            FilterClass.GetFilterSkins(ref items, argsClass);
            ViewBag.Skins = items;
            return View();
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
