using AMath.Calculus.common.Points;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMath.Calculus.Geometry
{
    internal abstract class BaseShapeBuilder<T> where T : struct, IEquatable<T>
    {
        public abstract BaseShape<T> Like(IEnumerable<Point<T>> points);
    }
}
