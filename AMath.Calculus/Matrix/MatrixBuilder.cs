using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMath.Calculus.Matrix
{
    public abstract class MatrixBuilder<T>
        where T : struct, IEquatable<T>
    {
        //public Matrix<T> Like(int rows, int columns)
        //{
        //    return new Matrix<T>(rows, columns);
        //}

        //public Matrix<T> Diagonal(int rows, int columns)
        //{
        //    return new DiagonalMatrix<T>(rows, columns);
        //}
    }
}
