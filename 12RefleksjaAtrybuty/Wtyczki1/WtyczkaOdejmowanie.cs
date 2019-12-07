using PluginInterfejs;

namespace Wtyczki1
{
	[MojAtrybutAttribute("Michał Włodarczyk", "Wtyczka umożliwia odejmowanie dwóch liczb rzeczywistych")]
	public class WtyczkaOdejmowanie : IMojPlugin
	{
		public string Menu=> "Odejmij dwie liczby"; 

		public double RobCos(double x, double y) => x - y;
	}
}
