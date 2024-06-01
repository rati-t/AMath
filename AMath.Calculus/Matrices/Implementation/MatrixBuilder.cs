using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMath.Calculus.Matrices.Implementation
{
    public class MatrixBuilder : BaseMatrixBuilder<float>
    {
        public override BaseMatrix<float> Like(int rows, int columns, float[] values)
        {
            return new Matrix(rows, columns, values.ToArray());
        }
    }
}
