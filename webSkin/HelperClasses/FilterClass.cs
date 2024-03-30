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
        }
    }
}
