using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PluginInterfejs
{
    public interface IMojPlugin
    {
        string Menu { get; }
        double RobCos(double x, double y);
    }
}
