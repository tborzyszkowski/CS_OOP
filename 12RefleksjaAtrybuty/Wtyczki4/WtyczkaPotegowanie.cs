using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginInterfejs;

namespace Wtyczki4
{
    [MojAtrybutAttribute("Tomasz Borzyszkowski", "Wtyczka umożliwia Pow(a, b)")]
    public class WtyczkaPotega : IMojPlugin {
        #region IMojPlugin Members

        public string Menu {
            get { return "Potega"; }
        }

        public double RobCos(double x, double y) {
            return Math.Pow(x,y);
        }

        #endregion
    }
}
