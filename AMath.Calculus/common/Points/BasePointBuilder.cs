using AMath.Calculus.common.Points.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMath.Calculus.common.Points
{
    internal abstract class BasePointBuilder<T> where T : struct, IEquatable<T>
    {
        public abstract Point<T> Create(ThreeDimensionalPoint other);
        public abstract Point<T> Create(TwoDimensionalPoint other);
    }
}
