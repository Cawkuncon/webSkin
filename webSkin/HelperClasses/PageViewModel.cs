namespace webSkin.HelperClasses
{
	public class PageViewModel
	{
		public int PageNumber { get; private set; }
		public int TotalPages { get; private set; }
		public int TotalCount { get; private set; }

		public PageViewModel(int count, int pageNumber, int pageSize)
		{
			PageNumber = pageNumber;
			TotalPages = (int)Math.Ceiling(count / (double)pageSize);
			TotalCount = count;
		}

		public bool HasPreviousPage
		{
			get
			{
				return (PageNumber > 1);
			}
		}
		public bool HasPrevPreviousPage
		{
			get
			{
				return (PageNumber > 2);
			}
		}

		public bool HasNextPage
		{
			get
			{
				return (PageNumber < TotalPages);
			}
		}
	}
}
