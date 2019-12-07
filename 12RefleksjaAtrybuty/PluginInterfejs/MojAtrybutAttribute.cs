using System;

namespace PluginInterfejs
{
	[AttributeUsage(AttributeTargets.Class)]
	public class MojAtrybutAttribute : Attribute
	{
		public string Autor { get; } 

		public string Opis { get;  }

		public MojAtrybutAttribute(string autor, string opis)
		{
			this.Autor = autor;
			this.Opis = opis;
		}
	}
}
