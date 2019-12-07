using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PluginInterfejs;

namespace Wtyczki2
{
	[MojAtrybutAttribute("Michał Włodarczyk", "Wtyczka umożliwia mnożenie dwóch liczb rzeczywistych")]
	public class WtyczkaMonozenie : IMojPlugin
	{
		public string Menu => "Mnoży dwie liczby";

		public double RobCos(double x, double y) => x * y;
	}
}
