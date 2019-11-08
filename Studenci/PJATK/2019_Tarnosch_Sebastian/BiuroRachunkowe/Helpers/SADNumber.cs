using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace BiuroRachunkowe.Helpers
{
	public static class SADNumber
	{
		public static IHtmlString SADNumberToFormat(this HtmlHelper helper, string nr)
		{
			nr = nr.ToUpper();
			if (!String.IsNullOrEmpty(nr))
			{

				if (nr.Contains('/'))
				{
					if (nr.Contains("OGL"))
					{
						var regex = @"\w\w\w\/\w\w\w\w\w\w\/\w\w\/\w\w\w\w\w\w\/\w\w\w\w";
						var match = Regex.Match(nr, regex);
						if (!match.Success)
						{
							nr = nr.Replace("/", string.Empty);
							nr = nr.Insert(3, "/");
							nr = nr.Insert(10, "/");
							nr = nr.Insert(13, "/");
							nr = nr.Insert(20, "/");

						}
					}
					else
					{
						nr = nr.Replace("/", string.Empty);
					}
				}
				else if (nr.Length == 21)
				{
					if (nr.Contains("OGL"))
					{
						nr = nr.Insert(3, "/");
						nr = nr.Insert(10, "/");
						nr = nr.Insert(13, "/");
						nr = nr.Insert(20, "/");
					}
				}

			}
			return new MvcHtmlString(nr);
		}
	}
}