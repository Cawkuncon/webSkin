using ParseTry.Main;
using webSkin.Models;

namespace webSkin.HelperClasses
{
	public static class FilterClass
	{
		public static void GetFilterSkins(ref List<ResultItem> items, SearchingClass argsClass)
		{
			if (argsClass.Type != null)
			{
				items = items.Where(skin => skin.buff_type_localized_name == argsClass.Type).ToList();
			}
			if (argsClass.Exterior != null)
			{
				items = items.Where(skin => skin.buff_exterior_localized_name == argsClass.Exterior).ToList();
			}
			if (argsClass.minPrice != null && argsClass.maxPrice != null)
			{
				items = items.Where(skin => skin.buff_sell_min_price >= argsClass.minPrice && skin.buff_sell_min_price <= argsClass.maxPrice).ToList();
			}
			if (argsClass.minBM != null && argsClass.maxBM != null)
			{
				items = items.Where(skin => skin.pricesBM >= argsClass.minBM && skin.pricesBM <= argsClass.maxBM).ToList();
			}
			if (argsClass.maxMB != null && argsClass.minMB != null)
			{
				items = items.Where(skin => skin.pricesMB >= argsClass.minMB && skin.pricesMB <= argsClass.maxMB).ToList();
			}
			if (argsClass.Sort != null)
			{
				if (argsClass.Sort == "order")
				{
					items = items.OrderBy(skin => skin.market_popularity_7d).ToList();
				}
				else if (argsClass.Sort == "orderDescending")
				{
					items = items.OrderByDescending(skin => skin.market_popularity_7d).ToList();
				}
			}
		}

		public static void SetSearchingArgs(ref ISearchingClass searchingClass, SearchingClass? searchingArgs, List<ResultItem> items)
		{
			var itemPrice = items.OrderBy(skin => skin.buff_sell_min_price);
			searchingClass.minPrice = searchingArgs?.minPrice ?? itemPrice.FirstOrDefault().buff_sell_min_price;
			searchingClass.maxPrice = searchingArgs?.maxPrice ?? itemPrice.LastOrDefault().buff_sell_min_price;
			var itemDivBM = items.OrderBy(skin => skin.pricesBM);
			searchingClass.minBM = searchingArgs?.minBM ?? itemDivBM.FirstOrDefault().pricesBM;
			searchingClass.maxBM = searchingArgs?.maxBM ?? itemDivBM.LastOrDefault().pricesBM;
			var itemDivMB = items.OrderBy(skin => skin.pricesMB);
			searchingClass.minMB = searchingArgs?.minMB ?? itemDivMB.FirstOrDefault().pricesMB;
			searchingClass.maxMB = searchingArgs?.maxMB ?? itemDivMB.LastOrDefault().pricesMB;
		}
	}
}
