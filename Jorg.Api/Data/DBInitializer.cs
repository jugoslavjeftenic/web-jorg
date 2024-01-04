using Jorg.Web.Models;
using Jorg.Web.Models.Enums;

namespace Jorg.Web.Data
{
	public static class DBInitializer
	{
		public static void InitializeDatabase(JorgDbContext jorgContext)
		{
			if (jorgContext.Countries.Any())
				return;

			var bih = new CountryModel()
			{
				Alpha = "BIH",
				Country = "Bosna i Hercegovina",
				Continent = ContinentEnum.Evropa
			};

			var mne = new CountryModel()
			{
				Alpha = "MNE",
				Country = "Crna Gora",
				Continent = ContinentEnum.Evropa
			};

			var hrv = new CountryModel()
			{
				Alpha = "HRV",
				Country = "Hrvatska",
				Continent = ContinentEnum.Evropa
			};

			var mkd = new CountryModel()
			{
				Alpha = "MKD",
				Country = "Republika Makedonija",
				Continent = ContinentEnum.Evropa
			};

			var svn = new CountryModel()
			{
				Alpha = "SVN",
				Country = "Slovenija",
				Continent = ContinentEnum.Evropa
			};

			var srb = new CountryModel()
			{
				Alpha = "SRB",
				Country = "Srbija",
				Continent = ContinentEnum.Evropa
			};

			jorgContext.Countries.Add(bih);
			jorgContext.Countries.Add(mne);
			jorgContext.Countries.Add(hrv);
			jorgContext.Countries.Add(mkd);
			jorgContext.Countries.Add(svn);
			jorgContext.Countries.Add(srb);

			jorgContext.SaveChanges();
		}
	}
}
