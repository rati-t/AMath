using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMath.Calculus.common.Points
{
    internal class ThreeDimensionalPoint<T> : Point<T> where T : struct, IEquatable<T>
    {
        protected T ZCoordinate { get; set; }
        public ThreeDimensionalPoint(T xCoordinate, T yCoordinate, T zCoordinate) : base(xCoordinate, yCoordinate)
        {
            ZCoordinate = zCoordinate;
        }
    }
}
