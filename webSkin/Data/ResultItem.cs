using System.ComponentModel.DataAnnotations;


namespace ParseTry.Main
{
    public class ResultItem
    {
        [Key]
        public string hash_name { get; set; }
        public decimal? market_buy_order { get; set; }
        public decimal buff_buy_max_price { get; set; }
        public decimal? market_price { get; set; }
        public decimal buff_sell_min_price { get; set; }
        public decimal buff_steam_price_cny { get; set; }
        public int buff_buy_num { get; set; }
        public int buff_sell_num { get; set; }
        public decimal pricesBM { get; set; }
        public decimal pricesMB { get; set; }
        public decimal pricesSM { get; set; }
        public decimal pricesMS { get; set; }
        public decimal pricesSB { get; set; }
        public decimal pricesBS { get; set; }
        public int? market_popularity_7d { get; set; }
        public string? buff_exterior_localized_name { get; set; }
        public string buff_type_localized_name { get; set; }
        public string buff_url_buff { get; set; }
        public string? market_url { get; set; }
        public string buff_steam_market_url { get; set; }
        public string buff_original_icon_url { get; set; }
    }
}
