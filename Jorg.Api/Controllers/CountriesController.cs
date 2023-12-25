using Jorg.Api.Data;
using Jorg.Api.Filters.ActionFilters;
using Jorg.Api.Filters.ExceptionFilters;
using Jorg.Api.Filters.ResourceFilters;
using Jorg.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jorg.Api.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class CountriesController(JorgDbContext db) : ControllerBase
	{
		private readonly JorgDbContext _db = db;

		// Create
		[HttpPost]
		[AllowEmptyJsonBody]
		[TypeFilter(typeof(Country_ValidateCreateCountryFilterAttribute))]
		public IActionResult CreateCountry([FromBody] CountryModel country)
		{
			_db.Countries.Add(country);
			_db.SaveChanges();

			return CreatedAtAction(nameof(GetCountryById),
				new { id = country.Id },
				country);
		}

		// Read
		[HttpGet]
		public IActionResult GetAllCountries()
		{
			return Ok(_db.Countries.ToList());
		}

		// Read
		[HttpGet("{id}")]
		[TypeFilter(typeof(Country_ValidateCountryIdFilterAttribute))]
		public IActionResult GetCountryById(int id)
		{
			return Ok(HttpContext.Items["country"]);
		}

		// Update
		[HttpPut("{id}")]
		[AllowEmptyJsonBody]
		[TypeFilter(typeof(Country_ValidateCountryIdFilterAttribute))]
		[Country_ValidateUpdateCountryFilter]
		[TypeFilter(typeof(Country_HandleUpdateExceptionsFilterAttribute))]
		public IActionResult UpdateCountry(int id, CountryModel country)
		{
			var countryToUpdate = HttpContext.Items["country"] as CountryModel;
			countryToUpdate!.Alpha = country.Alpha;
			countryToUpdate.Country = country.Country;
			countryToUpdate.Continent = country.Continent;

			_db.SaveChanges();

			return NoContent();
		}

		// Delete
		[HttpDelete("{id}")]
		[TypeFilter(typeof(Country_ValidateCountryIdFilterAttribute))]
		public IActionResult DeleteCountry(int id)
		{
			var countryToDelete = HttpContext.Items["country"] as CountryModel;

			_db.Countries.Remove(countryToDelete!);
			_db.SaveChanges();

			return Ok(countryToDelete);
		}
	}
}
