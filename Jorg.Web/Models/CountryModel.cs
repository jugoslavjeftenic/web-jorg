using Jorg.Web.Models.Enums;
using Jorg.Web.Models.Validations;
using System.ComponentModel.DataAnnotations;

namespace Jorg.Web.Models
{
	public class CountryModel
	{
		[Key] public int Id { get; set; }

		[Required(ErrorMessage = "Nedostaje Alpha kod države od 3 karaktera.")]
		[StringLength(3, ErrorMessage = "Dužina polja mora biti tačno 3 karaktera.")]
		public string? Alpha { get; set; }

		[Required(ErrorMessage = "Nedostaje naziv države.")]
		public string? Country { get; set; }

		[Required(ErrorMessage = "Nedostaje kontinent.")]
		[Country_EnsureCorrectContinentEnum]
		public ContinentEnum? Continent { get; set; }
	}
}
