using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMath.Calculus.common.FunctionalMath
{
    public static class FunctionalMath
    {
        private static readonly float _epsilon = 0.00001f;
        public static float CalculateDerivative(Func<float, float> func, float xValue, float hValue = 0.001f)
        {
            return (func(xValue + hValue) - func(xValue - hValue)) / (2 * hValue);
        }
        public static float CalculateIntegral(Func<float, float> func, float start, float end, int n = 2)
        {
            if (n % 2 != 0)
            {
                throw new ArgumentException("The number of intervals (n) must be even for Simpson's rule.");
            }

            float interval = (end - start) / n;
            float sum = func(start) + func(end);

            for (int i = 1; i < n; i++)
            {
                float x = start + i * interval;
                sum += i % 2 == 0 ? 2 * func(x) : 4 * func(x);
            }

            return (interval / 3) * sum;
        }

        public static float CalculateEquation(Func<float, float> func, float a, float b)
        {
            if (func(a) * func(b) >= 0)
            {
                throw new Exception("You have not assumed right a and b");
            }

            float c = a;
            while ((b - a) >= _epsilon)
            {
                c = (a + b) / 2;

                if (func(c) == 0.0)
                    break;

                else if (func(c) * func(a) < 0)
                    b = c;
                else
                    a = c;
            }
            return c;
        }
    }
}
