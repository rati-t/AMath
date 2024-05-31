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


        internal abstract BaseVector<T> Add(BaseVector<T> other);
        internal abstract BaseVector<T> Subtract(BaseVector<T> other);

        public static BaseVector<T> operator +(BaseVector<T> first, BaseVector<T> second)
        {
            return first.Add(second);
        }
    }
}
