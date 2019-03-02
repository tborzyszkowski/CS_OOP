using System;

namespace PluginInterfejs
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MojAtrybutAttribute : Attribute
    {
        private string autor;
        public string Autor
        {
            get { return autor; }
        }
        private string opis;
        public string Opis
        {
            get { return opis; }
        }

        public MojAtrybutAttribute(string autor, string opis)
        {
            this.autor = autor;
            this.opis = opis;
        }
    }
}
