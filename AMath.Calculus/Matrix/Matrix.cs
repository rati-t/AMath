using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMath.Calculus.Matrix
{
    public partial class Matrix<T>
        where T : struct, IEquatable<T>
    {
        private MatrixContent<T> _content { get; set; }
        public Matrix(MatrixContent<T> content)
        {
            if (content == null)
                throw new ArgumentNullException(nameof(content));

            // TODO: Check if dimension match, if not so throw exception

            RowCount = content.RowCount;
            ColumnCount = content.ColumnCount;
            _content = content;
        }
        public int RowCount { get; private set; }
        public int ColumnCount { get; private set; }

        public Matrix<T> Add(Matrix<T> addend)
        {
            if (IsValidForAddition(addend))
                throw new MatricesIsNotCompatibleForAddition();

            return null;
        }

        #region operators
        public static Matrix<T> operator +(Matrix<T> augend, Matrix<T> addend)
        {
            return augend.Add(addend);
        }

        #endregion

        #region Validation
        public bool IsValidForAddition(Matrix<T> addend)
        {
            if (addend.RowCount != RowCount || addend.ColumnCount != ColumnCount)
                return false;

            return true;
        }
        #endregion

        #region Abstract
        public virtual T Get(int row, int column)
        {
            return _content[row, column];
        }
        public virtual void Set(int row, int column, T value)
        {
            _content[row, column] = value;
        }
        #endregion


        internal virtual void Copy(Matrix<T> receiver, Matrix<T> seed)
        {
            for(int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    receiver.Set(i, j, seed.Get(i, j));
                }
            }
        }
    }
}
