using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculust.Matrix
{
    public class DiagonalMatrix<T> : Matrix<T>
        where T : struct, IEquatable<T>
    {
        public DiagonalMatrix(int rowCount, int columnCount)
            : base(rowCount, columnCount)
        {
                
        }

        public DiagonalMatrix(int rowCount, int columnCount, T[] content)
            : base(rowCount, columnCount, content)
        {
            if(content == null)
                throw new ArgumentNullException(nameof(content));

            // TODO: Check if dimension match, if not so throw exception
        }
    }
}
