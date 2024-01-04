using Jorg.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Jorg.Web.Data
{
	public class JorgDbContext(DbContextOptions<JorgDbContext> options) : DbContext(options)
	{
		//public DbSet<CountryModel> Countries { get; set; }
		public DbSet<CountryModel> Countries => Set<CountryModel>();
	}
}
