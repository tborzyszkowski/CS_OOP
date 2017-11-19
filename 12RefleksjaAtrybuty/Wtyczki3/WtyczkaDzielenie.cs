using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PluginInterfejs;


namespace Wtyczki3 {
    [MojAtrybutAttribute("Tomasz Borzyszkowski", "Wtyczka umożliwia dzielenie dwóch liczb rzeczywistych")]
    public class WtyczkaDzielenie : IMojPlugin {
        #region IMojPlugin Members

        public string Menu {
            get { return "Dzieli dwie liczby"; }
        }

        public double RobCos(double x, double y) {
            return x / y;
        }

        #endregion
    }
}
