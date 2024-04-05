namespace webSkin.Models
{
    public class SearchingClass: ISearchingClass
    {
        public decimal? minPrice { get; set; }
        public decimal? maxPrice { get; set; }
        public string Type { get; set; }
        public string Exterior { get; set; }
        public string Sort { get; set; }
        public decimal? minMB { get; set; }
        public decimal? maxMB { get; set; }
        public decimal? minBM { get; set; }
        public decimal? maxBM { get; set; }
		public bool firstInitialization { get; set; }
	}

	public interface ISearchingClass
	{
		public decimal? minPrice { get; set; }
		public decimal? maxPrice { get; set; }
		public string Type { get; set; }
		public string Exterior { get; set; }
		public string Sort { get; set; }
		public decimal? minMB { get; set; }
		public decimal? maxMB { get; set; }
		public decimal? minBM { get; set; }
		public decimal? maxBM { get; set; }
		public bool firstInitialization { get; set; }
	}
}
