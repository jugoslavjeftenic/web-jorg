using Jorg.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Jorg.Web.Filters.ActionFilters
{
	public class Country_ValidateCountryIdFilterAttribute(ApplicationDbContext db) : ActionFilterAttribute
	//public class Country_ValidateCountryIdFilterAttribute(JorgDbContext db) : ActionFilterAttribute
	{
		private readonly ApplicationDbContext _db = db;
		//private readonly JorgDbContext _db = db;

		public override void OnActionExecuting(ActionExecutingContext context)
		{
			base.OnActionExecuting(context);

			var countryID = context.ActionArguments["id"] as int?;
			if (countryID.HasValue)
			{
				if (countryID.Value <= 0)
				{
					context.ModelState.AddModelError("CountryID", "ID Države nije validan.");
					var problemDetails = new ValidationProblemDetails(context.ModelState)
					{
						Status = StatusCodes.Status400BadRequest
					};
					context.Result = new BadRequestObjectResult(problemDetails);
				}
				else
				{
					var country = _db.Countries.Find(countryID.Value);
					if (country == null)
					{
						context.ModelState.AddModelError("CountryID", "Država ne postoji.");
						var problemDetails = new ValidationProblemDetails(context.ModelState)
						{
							Status = StatusCodes.Status404NotFound
						};
						context.Result = new NotFoundObjectResult(problemDetails);
					}
					else
					{
						context.HttpContext.Items["country"] = country;
					}
				}
			}
		}
	}
}
