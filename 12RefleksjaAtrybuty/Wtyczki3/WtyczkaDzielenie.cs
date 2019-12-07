using PluginInterfejs;


namespace Wtyczki3
{
	[MojAtrybutAttribute("Tomasz Borzyszkowski", "Wtyczka umożliwia dzielenie dwóch liczb rzeczywistych")]
	public class WtyczkaDzielenie : IMojPlugin
	{
		public string Menu => "Dzieli dwie liczby";

		public double RobCos(double x, double y) => x / y;
	}
}
