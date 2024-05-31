using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
namespace AMath.Calculus.common.Points
{
    internal abstract class Point<T> where T : struct, IEquatable<T>
    {     
        internal T XCoordinate { get; set; }
        internal T YCoordinate { get; set; }

        public Point(T xCoordinate, T yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }

        public override bool Equals(object? obj)
        {
            if (obj != null && obj is TwoDimensionalPoint other)
            {
                return XCoordinate.Equals(other.XCoordinate) && YCoordinate.Equals(other.YCoordinate);
            }
            return false;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public abstract Point<T> Add(Point<T> other);
        public abstract Point<T> Subtract(Point<T> other);

        public static Point<T> operator +(Point<T> first, Point<T> second)
        {
            return first.Add(second);
        }
        public static Point<T> operator -(Point<T> first, Point<T> second)
        {
            return first.Subtract(second);
        }

    }
}
