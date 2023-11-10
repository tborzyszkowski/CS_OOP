namespace PrivateProperty {

	internal class Property {
		private int _x { get; public set; } = 0;
	}
	internal class Program {
		static void Main(string[] args) {
			Property property = new Property();
			property._x = 1;
		}
	}
}