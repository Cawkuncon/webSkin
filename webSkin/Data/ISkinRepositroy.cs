using ParseTry.Main;

namespace webSkins.Data
{
	public interface ISkinRepositroy
	{
        public Task<List<ResultItem>> GetAllSkinsAsync();
        public Task<ResultItem> GetSkinAsync(string hash_name);

    }
}