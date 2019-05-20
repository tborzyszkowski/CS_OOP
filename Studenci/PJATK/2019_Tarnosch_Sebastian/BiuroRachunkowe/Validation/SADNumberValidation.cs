using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BiuroRachunkowe.Validation
{
	public class SADNumberValidation :  ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value != null)
			{
				string nr = value.ToString();
				if (nr.Contains('/') && nr.Contains("OGL"))
				{

					var regex = @"\w\w\w\/\w\w\w\w\w\w\/\w\w\/\w\w\w\w\w\w\/\w\w\w\w";
					var match = Regex.Match(nr, regex);
					if (!match.Success)
						return new ValidationResult("Numer SAD jest w złym formacie! Przykładowy prawidłowy format: OGL/322070/00/262020/2017 albo  OGL322070002620202017");
					else
						return ValidationResult.Success;



				}
				else if (nr.Length == 21 && nr.Contains("OGL"))
					return ValidationResult.Success;

				return new ValidationResult("Numer SAD jest w złym formacie! Przykładowy prawidłowy format: OGL/322070/00/262020/2017 albo OGL322070002620202017");

			}
			return new ValidationResult("Numer SAD nie może być pusty");
		}
	}
}