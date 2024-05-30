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

        public override Point<T> Add(Point<T> other)
        {
            return new TwoDimensionalPoint<float>(XCoordinate + other.XCoordinate);
        }

        public override Point<T> Subtract(Point<T> other)
        {
            throw new NotImplementedException();
        }
    }
}
