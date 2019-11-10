using Antlr.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace BiuroRachunkowe.Helpers
{
	public static class Date
	{
		public static IHtmlString DateToFormat(this HtmlHelper helper, DateTime date)
		{
			return new MvcHtmlString(date.ToString("yyyy-MM-dd"));
		}


	}

}
