using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
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
		private int pageSize = 20;
		public HomeController(ILogger<HomeController> logger, ISkinRepositroy skinRepositroy, IMemoryCache memoryCache)
		{
			_logger = logger;
			this.skinRepositroy = skinRepositroy;
			cache = memoryCache;
		}

		public async Task<IActionResult> IndexAsync(int page = 1)
		{
			cache.TryGetValue("skins", out items);
			if (items == null)
			{
				items = await skinRepositroy.GetAllSkinsAsync();
				cache.Set("skins", items, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(20)));
				flagToResetFilter = false;
				cache.Set("flagToResetFilter", flagToResetFilter);
			}
			var count = items.Count;
			items = items.Skip((page - 1) * pageSize).Take(pageSize).ToList();
			var pageViewModel = new PageViewModel(count, page, pageSize);
			var indexViewModel = new IndexViewModel()
			{
				PageViewModel = pageViewModel,
				Items = items
			};
			ViewBag.IndexViewModel = indexViewModel;
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> IndexAsync(SearchingClass argsClass, string Reset, int page = 1)
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
			var count = items.Count;
			items = items.Skip((page - 1) * pageSize).Take(pageSize).ToList();
			var pageViewModel = new PageViewModel(count, page, pageSize);
			var indexViewModel = new IndexViewModel()
			{
				PageViewModel = pageViewModel,
				Items = items
			};
			ViewBag.IndexViewModel = indexViewModel;
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
