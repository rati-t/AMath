using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMath.Calculus.common.Trigonometry
{
    public static class TrigonometryExtension
    {
        private static readonly int PrecisionRounding = 15;
        public static double Sin(double radians)
        {
            return Math.Round(Math.Sin(radians), PrecisionRounding);
        }

        public static double Cos(double radians)
        {
            return Math.Round(Math.Cos(radians), PrecisionRounding);
        }

    }
}
