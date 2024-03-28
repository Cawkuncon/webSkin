using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using ParseTry.Main;
using webSkin.Data;

namespace webSkins.Data
{
	public class SkinDbRepositroy : ISkinRepositroy
	{
		readonly ApplicationDbContext appContext;

		public SkinDbRepositroy(ApplicationDbContext appContext)
		{
			this.appContext = appContext;
		}

		public async Task<List<ResultItem>> GetAllSkinsAsync()
		{
			return await appContext.ResultItems.ToListAsync();
		}

		public async Task<ResultItem> GetSkinAsync(string hash_name) => await appContext.ResultItems.FirstOrDefaultAsync(skin => skin.hash_name == hash_name);

	}
}
