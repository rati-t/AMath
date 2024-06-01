using AMath.Calculus.common.Points;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMath.Calculus.Vectors
{
    public abstract class BaseVector<T> where T : struct, IEquatable<T>
    {
        internal Point<T> StartPoint { get; set; }
        internal Point<T> EndPoint { get; set; }
        internal Point<T> ActualPoint { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj != null && obj is BaseVector<T> other)
            {
                return StartPoint.Equals(other.StartPoint) && EndPoint.Equals(other.EndPoint) && ActualPoint.Equals(other.ActualPoint);
            }
            return false;
        }


        public abstract BaseVector<T> Add(BaseVector<T> other);
        public abstract BaseVector<T> Subtract(BaseVector<T> other);
        public abstract BaseVector<T> Divide(BaseVector<T> other);
        public abstract BaseVector<T> ScalarMultiply(T other);
        public abstract BaseVector<T> ScalarDivide(T other);
        public abstract BaseVector<T> Multiply(BaseVector<T> other);
        public abstract T DotProduct(BaseVector<T> other);
        public abstract BaseVector<T> CrossProduct(BaseVector<T> other);
        public abstract BaseVector<T> NormilizeVector();
        public abstract BaseVector<T> Projection(BaseVector<T> other);

        public static BaseVector<T> operator +(BaseVector<T> first, BaseVector<T> second)
        {
            return first.Add(second);
        }
        public static BaseVector<T> operator -(BaseVector<T> first, BaseVector<T> second)
        {
            return first.Subtract(second);
        }

        public static bool operator ==(BaseVector<T> first, BaseVector<T> second)
        {
            return first.Equals(second);
        }
        public static bool operator !=(BaseVector<T> first, BaseVector<T> second)
        {
            return !first.Equals(second);
        }

        public static BaseVector<T> operator *(BaseVector<T> first, T second)
        {
            return first.ScalarMultiply(second);
        }
        public static BaseVector<T> operator *(T first, BaseVector<T> second)
        {
            return second.ScalarMultiply(first);
        }

        public static BaseVector<T> operator *(BaseVector<T> first, BaseVector<T> second)
        {
            return first.Multiply(second);
        }
        public static BaseVector<T> operator /(BaseVector<T> first, T second)
        {
            return first.ScalarDivide(second);
        }

        public static BaseVector<T> operator /(BaseVector<T> first, BaseVector<T> second)
        {
            return first.Divide(second);
        }


    }
}
