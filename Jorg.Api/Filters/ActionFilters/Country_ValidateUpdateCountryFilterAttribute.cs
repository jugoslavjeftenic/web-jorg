using Jorg.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Jorg.Api.Filters.ActionFilters
{
	public class Country_ValidateUpdateCountryFilterAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			base.OnActionExecuting(context);

			var countryID = context.ActionArguments["id"] as int?;
			var country = context.ActionArguments["country"] as CountryModel;

			if (countryID.HasValue && country != null && countryID != country.Id)
			{
				context.ModelState.AddModelError("Country", "ID i ID države nisu isti.");
				var problemDetails = new ValidationProblemDetails(context.ModelState)
				{
					Status = StatusCodes.Status400BadRequest
				};
				context.Result = new BadRequestObjectResult(problemDetails);
			}
		}
	}
}
