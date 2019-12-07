using System;
using PluginInterfejs;

namespace Wtyczki4
{
	[MojAtrybutAttribute("Tomasz Borzyszkowski", "Wtyczka umożliwia Pow(a, b)")]
	public class WtyczkaPotega : IMojPlugin
	{
		public string Menu => "Potega"; 

		public double RobCos(double x, double y) => Math.Pow(x, y);
		
	}
}
