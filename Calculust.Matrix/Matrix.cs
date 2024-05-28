using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculust.Matrix
{
    public abstract partial class Matrix<T>
        where T : struct, IEquatable<T>
    {
        private T[] _content { get; set; }
        protected Matrix(int rowCount, int columnCount)
        {
            RowCount = rowCount;
            ColumnCount = columnCount;
        }
        protected Matrix(int rowCount, int columnCount, T[] content)
        {
            if(content == null)
                throw new ArgumentNullException(nameof(content));

            // TODO: Check if dimension match, if not so throw exception

            RowCount = rowCount;
            ColumnCount = columnCount;
            _content = content;
        }
        public int RowCount { get; private set; }
        public int ColumnCount { get; private set; }

        public Matrix<T> Add(Matrix<T> addend)
        {
            if(addend.RowCount != RowCount || addend.ColumnCount != ColumnCount)
            {
                // TODO: Custom exception with valid message
                throw new ArgumentException();
            }

            return 
        }

        #region operators
        public static Matrix<T> operator +(Matrix<T> augend, Matrix<T> addend)
        {
            return augend.Add(addend);
        }

        #endregion

        #region Abstract
        public abstract T Get(int row, int column);
        public abstract void Set(int row, int column, T value);
        #endregion
    }
}
