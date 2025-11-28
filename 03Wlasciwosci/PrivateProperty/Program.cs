namespace PrivateProperty {

	public class Property
    {
        private int _x;
        public int X
        {
            get { return _x;}
            internal set { _x = value; }
        }
	}
	internal class Program {
		static void Main(string[] args) {
			Property property = new Property();
			property.X = 1;
			Console.WriteLine(property.X);
		}
	}
}