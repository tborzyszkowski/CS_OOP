using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PluginInterfejs;

namespace Wtyczki1
{
    [MojAtrybutAttribute("Michał Włodarczyk", "Wtyczka umożliwia dodanie dwóch liczb rzeczywistych")]
    public class WtyczkaDodawanie : IMojPlugin
    {
        #region IMojPlugin Members

        public string Menu
        {
            get { return "Dodaj dwie liczby"; }
        }

        public double RobCos(double x, double y)
        {
            return x + y;
        }

        #endregion
    }
}
