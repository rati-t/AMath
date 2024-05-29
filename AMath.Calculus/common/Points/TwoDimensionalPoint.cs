using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMath.Calculus.common.Points
{
    internal class TwoDimensionalPoint<T> : Point<T> where T : struct, IEquatable<T>
    {
        public TwoDimensionalPoint(T xCoordinate, T yCoordinate) : base(xCoordinate, yCoordinate)
        { 
        }
    }
}
