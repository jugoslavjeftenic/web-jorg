using Jorg.Web.Data;
using Jorg.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Jorg.Web.Filters.ActionFilters
{
	public class Country_ValidateCreateCountryFilterAttribute(ApplicationDbContext db) : ActionFilterAttribute
	//public class Country_ValidateCreateCountryFilterAttribute(JorgDbContext db) : ActionFilterAttribute
	{
		private readonly ApplicationDbContext _db = db;
		//private readonly JorgDbContext _db = db;

		public override void OnActionExecuting(ActionExecutingContext context)
		{
			base.OnActionExecuting(context);

			if (context.ActionArguments["country"] is not CountryModel country)
			{
				context.ModelState.AddModelError("Country", "Država je null.");
				var problemDetails = new ValidationProblemDetails(context.ModelState)
				{
					Status = StatusCodes.Status400BadRequest
				};
				context.Result = new BadRequestObjectResult(problemDetails);
			}
			else
			{
				var existingCountry = _db.Countries.FirstOrDefault(x =>
					!string.IsNullOrWhiteSpace(country.Alpha) &&
					!string.IsNullOrWhiteSpace(x.Alpha) &&
					x.Alpha.ToLower() == country.Alpha.ToLower() &&
					!string.IsNullOrWhiteSpace(country.Country) &&
					!string.IsNullOrWhiteSpace(x.Country) &&
					x.Country.ToLower() == country.Country.ToLower() &&
					country.Continent.HasValue &&
					x.Continent.HasValue &&
					country.Continent.Value == x.Continent.Value);
				if (existingCountry != null)
				{
					context.ModelState.AddModelError("Country", "Država već postoji.");
					var problemDetails = new ValidationProblemDetails(context.ModelState)
					{
						Status = StatusCodes.Status400BadRequest
					};
					context.Result = new BadRequestObjectResult(problemDetails);
				}
			}
		}
	}
}
