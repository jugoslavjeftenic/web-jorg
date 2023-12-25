using Jorg.Api.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Jorg.Api.Models.Validations
{
	public class Country_EnsureCorrectContinentEnumAttribute : ValidationAttribute
	{
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			var country = validationContext.ObjectInstance as CountryModel;

			if (country is not null)
			{
				if (country.Continent < ContinentEnum.Afrika || country.Continent > ContinentEnum.JuznaAmerika)
				{
					return new ValidationResult
						("Pogrešan kontinent. (0)Afrika (1)Antartika (2)Azija (3)Evropa (4)SevernaAmerika (5)Okeanija (6)JuznaAmerika");
				}
			}

			return ValidationResult.Success;
		}
	}
}
