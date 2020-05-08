using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace integral
{
    public interface IMath
    {
        double Trap(double a, double b, double h, Func<double, double> func);
        double Sims(double a, double b, double h, Func<double, double> func);
    }
}
