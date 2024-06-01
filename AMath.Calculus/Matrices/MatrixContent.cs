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
            if (content.Length != rowCount * columnCount)
                throw new Exception();

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
        public int RowCount { get; internal set; }
        public int ColumnCount { get; internal set; }

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

        public IEnumerable<T> GetRow(int row)
        {
            if (!IsRowInRange(row))
                throw MatrixExceptionHelper.Build(new RowOutOfRangeException());

            return Values.Where((a, i) => i % RowCount == row);
        }

        public IEnumerable<T> GetColumn(int column)
        {
            if (!IsColumnInRange(column))
                throw MatrixExceptionHelper.Build(new RowOutOfRangeException());

            return Values.Where((a, i) => i / RowCount == column);
        }


        public int GetIndex(int row, int column) => column * RowCount + row;
        public int GetTransposedIndex(int row, int column) => row * ColumnCount + column;
        public (int, int) GetCoordinates(int index) => (NthRow(index), NthColumn(index));

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

        internal int NthRow(int index) => index % RowCount;
        internal int NthColumn(int index) => index / RowCount;

        #endregion

    }
}
