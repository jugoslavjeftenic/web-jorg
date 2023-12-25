using Jorg.Api.Models.Enums;

namespace Jorg.Api.Models.Repositories
{
	public class CountryRepository
	{
		private static readonly List<CountryModel> _countries = [
			new CountryModel
			{
				Id = 1,
				Alpha = "BIH",
				Country = "Bosna i Hercegovina",
				Continent = ContinentEnum.Evropa
			},
			new CountryModel
			{
				Id = 2,
				Alpha = "MNE",
				Country = "Crna Gora",
				Continent = ContinentEnum.Evropa
			},
			new CountryModel
			{
				Id = 3,
				Alpha = "HRV",
				Country = "Hrvatska",
				Continent = ContinentEnum.Evropa
			},
			new CountryModel
			{
				Id = 4,
				Alpha = "MKD",
				Country = "Republika Makedonija",
				Continent = ContinentEnum.Evropa
			},
			new CountryModel
			{
				Id = 5,
				Alpha = "SVN",
				Country = "Slovenija",
				Continent = ContinentEnum.Evropa
			},
			new CountryModel
			{
				Id = 6,
				Alpha = "SRB",
				Country = "Srbija",
				Continent = ContinentEnum.Evropa
			}
		];

		public static bool CountryExist(int id)
		{
			return _countries.Any(x => x.Id == id);
		}

		public static void AddCountry(CountryModel country)
		{
			int maxId = _countries.Max(x => x.Id);
			country.Id = maxId + 1;

			_countries.Add(country);
		}

		public static List<CountryModel> GetAllCountries()
		{
			return _countries;
		}

		public static CountryModel? GetCountryById(int id)
		{
			return _countries.FirstOrDefault(x => x.Id == id);
		}

		public static CountryModel? GetCountryByProperties(string? alpha, string? country,
			ContinentEnum? continent)
		{
			return _countries.FirstOrDefault(x =>
				!string.IsNullOrWhiteSpace(alpha) &&
				!string.IsNullOrWhiteSpace(x.Alpha) &&
				x.Alpha.Equals(alpha, StringComparison.OrdinalIgnoreCase) &&
				!string.IsNullOrWhiteSpace(country) &&
				!string.IsNullOrWhiteSpace(x.Country) &&
				x.Country.Equals(country, StringComparison.OrdinalIgnoreCase) &&
				continent.HasValue &&
				x.Continent.HasValue &&
				continent.Value == x.Continent.Value);
		}

		public static void UpdateCountry(CountryModel country)
		{
			var countryToUpdate = _countries.First(x => x.Id == country.Id);
			countryToUpdate.Alpha = country.Alpha;
			countryToUpdate.Country = country.Country;
			countryToUpdate.Continent = country.Continent;
		}

		public static void DeleteCountry(int id)
		{
			var country = GetCountryById(id);
			if (country != null)
			{
				_countries.Remove(country);
			}
		}
	}
}
