using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace AMath.Calculus
{
    public static class AlgebraicOperations
    {
        private static void Check<T>(T[] a, T[] b)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }

            if (b == null)
            {
                throw new ArgumentNullException(nameof(b));
            }

            if (a.Length != b.Length)
            {
                throw new ArgumentException("Dimensions of provided arrays do not match");
            }
        }

        public static Complex[] AddArrays(Complex[] a, Complex[] b)
        {
            Check(a, b);

            var result = new Complex[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                result[i] = a[i] + b[i];
            }
            return result;
        }
    }
}
