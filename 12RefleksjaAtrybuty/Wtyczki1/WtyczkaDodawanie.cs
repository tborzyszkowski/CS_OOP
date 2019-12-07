using PluginInterfejs;

namespace Wtyczki1
{
	[MojAtrybutAttribute("Michał Włodarczyk", "Wtyczka umożliwia dodanie dwóch liczb rzeczywistych")]
	public class WtyczkaDodawanie : IMojPlugin
	{
		public string Menu => "Dodaj dwie liczby"; 

		public double RobCos(double x, double y) => x + y;
	}
}
