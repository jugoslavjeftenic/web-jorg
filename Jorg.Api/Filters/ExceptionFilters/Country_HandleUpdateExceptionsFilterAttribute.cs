using Jorg.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Jorg.Api.Filters.ExceptionFilters
{
	public class Country_HandleUpdateExceptionsFilterAttribute(JorgDbContext db) : ExceptionFilterAttribute
	{
		private readonly JorgDbContext _db = db;

		public override void OnException(ExceptionContext context)
		{
			base.OnException(context);

		}
	}
}
