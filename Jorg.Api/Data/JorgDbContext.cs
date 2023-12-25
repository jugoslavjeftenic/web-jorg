using Jorg.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Jorg.Api.Data
{
	public class JorgDbContext(DbContextOptions<JorgDbContext> options) : DbContext(options)
	{
		//public DbSet<CountryModel> Countries { get; set; }
		public DbSet<CountryModel> Countries => Set<CountryModel>();
	}
}
