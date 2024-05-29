using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMath.Calculus.Matrices.Implementation
{
    public class MatrixBuilder : IMatrixBuilder<float>
    {
        public override IMatrix<float> Like(int rows, int columns)
        {
            return new Matrix(rows, columns);
        }
    }
}
