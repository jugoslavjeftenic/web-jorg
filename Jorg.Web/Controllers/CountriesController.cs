using Jorg.Web.Data;
using Jorg.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jorg.Web.Controllers
{
	public class CountriesController(IWebApiExecutor webApiExecutor) : Controller
	{
		private readonly IWebApiExecutor _webApiExecutor = webApiExecutor;

		public async Task<IActionResult> Index()
		{
			return View(await _webApiExecutor.InvokeGet<List<CountryModel>>("countries"));
		}

		public IActionResult CreateCountry()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateCountry(CountryModel countryModel)
		{
			return View(countryModel);
		}
	}
}
