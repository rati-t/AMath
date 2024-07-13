using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMath.Calculus.common
{
    internal static class Helper
    {
        private static readonly int PrecisionRounding = 15;
        internal static double GetHypotenuse(double a, double b)
        {
            return Math.Round(
                Math.Sqrt(
                    Math.Pow(a, 2) + Math.Pow(b, 2)
                ), PrecisionRounding);
        }
    }
}
