using Jorg.Web.Models.Enums;
using Jorg.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Jorg.Web.Data
{
	public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
	{
		public DbSet<CountryModel> Countries { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// data seeding
			modelBuilder.Entity<CountryModel>().HasData(
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
			);
		}
	}
}
