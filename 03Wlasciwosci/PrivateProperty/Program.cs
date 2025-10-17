namespace PrivateProperty {

	internal class Property {
		 internal int _x { get;  set; } = 0;
	}
	internal class Program {
		static void Main(string[] args) {
			Property property = new Property();
			property._x = 1;
		}
	}
}