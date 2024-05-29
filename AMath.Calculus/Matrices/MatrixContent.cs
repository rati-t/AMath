using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMath.Calculus.Matrices
{
    public class MatrixContent<T>
        where T : struct, IEquatable<T>
    {
        public MatrixContent(int rowCount, int columnCount, T[] content)
        {
            Values = content;
            RowCount = rowCount;
            ColumnCount = columnCount;
        }

        public MatrixContent(int rowCount, int columnCount)
        {
            Values = new T[rowCount * columnCount];
            RowCount = rowCount;
            ColumnCount = columnCount;
        }

        internal T[] Values { get; set; }
        public int RowCount { get; private set; }
        public int ColumnCount { get; private set; }

        public T this[int row, int column]
        {
            get
            {
                if (!IsRowInRange(row))
                    throw MatrixExceptionHelper.Build(new RowOutOfRangeException());

                if (!IsColumnInRange(column))
                    throw MatrixExceptionHelper.Build(new ColumnOutOfRangeException());

                return Values[GetIndex(row, column)];
            }

            set
            {
                if (!IsRowInRange(row))
                    throw MatrixExceptionHelper.Build(new RowOutOfRangeException());

                if (!IsColumnInRange(column))
                    throw MatrixExceptionHelper.Build(new ColumnOutOfRangeException());

                Values[GetIndex(row, column)] = value;
            }
        }

        public int GetIndex(int row, int column) => column * RowCount + row;

        #region Validation
        public bool IsInRange(int row, int column)
        {
            return IsRowInRange(row) || IsColumnInRange(column);
        }

        public bool IsRowInRange(int row)
        {
            return row >= 0 && row < RowCount;
        }

        public bool IsColumnInRange(int column)
        {
            return column >= 0 && column < ColumnCount;
        }
        #endregion

    }
}
