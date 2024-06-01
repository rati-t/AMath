using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMath.Calculus.common.Points;
using AMath.Calculus.Matrices;
using AMath.Calculus.Matrices.Implementation;
using AMath.Calculus.Vectors;

namespace AMath.Calculus.Geometry
{
    public abstract class BaseShape<T> where T : struct, IEquatable<T>
    {  
        public BaseShape(BaseMatrix<T> matrix)
        {
            Matrix = matrix;
        }
        internal BaseMatrix<T> Matrix { get; set; }
        public abstract void Translate(BaseVector<T> vector);
        public abstract void Rotate(int degree);
        public abstract void Reflect(T m, T c);
        public abstract void GlideAndReflect(BaseVector<T> vector, T m, T c);
        public abstract void Scale(BaseVector<T> vector);
        public T[] GetCoordinateArray()
        {
            return Matrix.Content.Values;
        }
        internal abstract IEnumerable<Point<T>> GetPoints(BaseMatrix<T> matrix);
    }
}
