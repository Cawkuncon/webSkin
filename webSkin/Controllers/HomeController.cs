using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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
        private IMemoryCache cache;
        private List<ResultItem> items;
        private bool flagToResetFilter;
        public HomeController(ILogger<HomeController> logger, ISkinRepositroy skinRepositroy, IMemoryCache memoryCache)
        {
            _logger = logger;
            this.skinRepositroy = skinRepositroy;
            cache = memoryCache;
        }

        public async Task<IActionResult> IndexAsync()
        {
            cache.TryGetValue("skins", out items);
            if (items == null)
            {
                items = await skinRepositroy.GetAllSkinsAsync();
                cache.Set("skins", items, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(20)));
                flagToResetFilter = false;
                cache.Set("flagToResetFilter", flagToResetFilter);
			}
            ViewBag.Skins = items;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(SearchingClass argsClass, string Reset)
        {
            if (Reset != null)
            {
				items = await skinRepositroy.GetAllSkinsAsync();
				cache.Set("skins", items, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(20)));
				flagToResetFilter = false;
				cache.Set("flagToResetFilter", flagToResetFilter);
			}
            else
            {
				cache.TryGetValue("skins", out items);
				cache.TryGetValue("flagToResetFilter", out flagToResetFilter);
				if (items == null || (items != null && flagToResetFilter))
				{
					items = await skinRepositroy.GetAllSkinsAsync();
				}
				FilterClass.GetFilterSkins(ref items, argsClass);
				cache.Set("skins", items, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(20)));
				flagToResetFilter = true;
				cache.Set("flagToResetFilter", flagToResetFilter);
			}
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
