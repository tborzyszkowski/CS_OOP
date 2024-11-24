
namespace _01Czolg
{
	struct Punkt
	{
		private int x;
		private int y;

		public Punkt(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public int GetX()
		{
			return x;
		}
		public int GetY()
		{
			return y;
		}
		#region Zadanie 2
		public void SetX(int noweX)
		{
			x = noweX;
		}
		public void SetY(int noweY)
		{
			y = noweY;
		}
		#endregion
	}
}
