using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMath.Calculus.Vectors
{
    public class Vector<T> where T : struct
    {
        public T XCoordinate {  get; set; }
        public T YCoordinate { get; set; }

        public Vector(T x, T y)
        {
            XCoordinate = x;
            YCoordinate = y;
        }
    }
}
