using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AMath.Calculus.common.Points.Implementation;

namespace AMath.Calculus.common.Points
{
    public abstract class Point<T> where T : struct, IEquatable<T>
    {     
        protected BasePointBuilder<T>? _builder;
        internal T XCoordinate { get; set; }
        internal T YCoordinate { get; set; }

        public Point(T xCoordinate, T yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public abstract Point<T> Add(Point<T> other);
        public abstract Point<T> Subtract(Point<T> other);
        public abstract Point<T> MultiplyByNumber(T other);
        public abstract Point<T> Multiply(Point<T> other);
        public abstract Point<T> DevideByNumber(T other);
        public abstract Point<T> Devide(Point<T> other);
        public abstract T DotProduct(Point<T> other);
        public abstract T NormilizeValue();
        public abstract bool IsOrigin();
        public abstract T[] GetCoordinates();

        public static Point<T> operator +(Point<T> first, Point<T> second)
        {
            return first.Add(second);
        }
        public static Point<T> operator -(Point<T> first, Point<T> second)
        {
            return first.Subtract(second);
        }

        public static bool operator ==(Point<T> first, Point<T> second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(Point<T> first, Point<T> second)
        {
            return !first.Equals(second);
        }
        public static Point<T> operator *(Point<T> first, T second)
        {
            return first.MultiplyByNumber(second);
        }

        public static Point<T> operator *(Point<T> first, Point<T> second)
        {
            return first.Multiply(second);
        }

        public static Point<T> operator /(Point<T> first, T second)
        {
            return first.DevideByNumber(second);
        }

        public static Point<T> operator /(Point<T> first, Point<T> second)
        {
            return first.Devide(second);
        }


    }
}
