using AMath.Calculus.common.Points;
using AMath.Calculus.Matrices.Implementation;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AMath.Calculus.Matrices
{
    public abstract class BaseMatrix<T>
        where T : struct, IEquatable<T>
    {
        internal BaseMatrixBuilder<T> _builder;
        internal MatrixContent<T> Content { get; set; }
        public BaseMatrix(MatrixContent<T> content)
        {
            if (content == null)
                throw new ArgumentNullException(nameof(content));

            // TODO: Check if dimension match, if not so throw exception

            Content = content;
        }

        protected BaseMatrix(int rows, int columns, T[] values) : this(new MatrixContent<T>(rows, columns, values))
        {

        }

        public int RowCount { get { return Content.RowCount; } }
        public int ColumnCount { get { return Content.ColumnCount; } }
        public bool IsSquareMatrix
        {
            get
            {
                return RowCount == ColumnCount;
            }
        }

        public bool IsDiagonalMatrix
        {
            get
            {
                if (!IsSquareMatrix)
                    return false;

                return IsNonDiagonalAllZeroes();
            }
        }

        public abstract T GetDeterminant();
        public BaseMatrix<T> GetMinor(int rowToRemove, int columnToRemove)
        {
            T[] values = new T[(RowCount - 1) * (ColumnCount - 1)];

            var idx = 0;
            for (int i = 0; i < RowCount; i++)
            {
                if (i == columnToRemove)
                    continue;
                for (int j = 0; j < ColumnCount; j++)
                {
                    if(j == rowToRemove)
                        continue;
                    values[idx] = Get(j, i);
                    idx++;
                }
            }

            return _builder.Like(RowCount - 1, ColumnCount - 1, values);
        }
        public int GetIndex(int row, int column) => Content.GetIndex(row, column);
        public int GetTransposedIndex(int row, int column) => Content.GetTransposedIndex(row, column);
        public (int, int) GetCoordinates(int index) => Content.GetCoordinates(index);
        public void Transpose()
        {
            var values = Content.Values.ToArray();
            var result = new T[values.Length];

            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    result[GetTransposedIndex(i, j)] = values[GetIndex(i, j)];
                }
            }

            Content.Values = result;

            var rowCount = RowCount;
            Content.RowCount = ColumnCount;
            Content.ColumnCount = rowCount;
        }

        #region Addition
        public void Add(BaseMatrix<T> addend)
        {
            if (!IsValidForAddition(addend))
                throw MatrixExceptionHelper.Build(new MatricesIsNotCompatibleForAddition());

            Add(this, addend);
        }
        internal abstract void Add(BaseMatrix<T> augend, BaseMatrix<T> addend);
        public void Add(T scalar) => Add(this, scalar);
        internal abstract void Add(BaseMatrix<T> augend, T addend);
        public void AddToRow(T[] values, int row)
        {
            if (!IsValidForRowAddition(values))
                throw MatrixExceptionHelper.Build(new MatrixAndRowNotCompatibleForAddition());

            AddToRow(this, values, row);
        }
        internal abstract void AddToRow(BaseMatrix<T> augend, T[] values, int row);
        public void AddToRow(T scalar, int row) => AddToRow(this, scalar, row);
        internal abstract void AddToRow(BaseMatrix<T> augend, T addend, int row);
        public void AddToColumn(T[] values, int column)
        {
            if (!IsValidForColumnAddition(values))
                throw MatrixExceptionHelper.Build(new MatrixAndColumnNotCompatibleForAddition());

            AddToColumn(this, values, column);
        }
        internal abstract void AddToColumn(BaseMatrix<T> augend, T[] values, int column);
        public void AddToColumn(T scalar, int column) => AddToColumn(this, scalar, column);
        internal abstract void AddToColumn(BaseMatrix<T> augend, T addend, int column);
        #endregion

        #region Subtruction
        public void Subtruct(BaseMatrix<T> subtrahend)
        {
            if (!IsValidForAddition(subtrahend))
                throw MatrixExceptionHelper.Build(new MatricesIsNotCompatibleForSubtruction());

            Subtruct(this, subtrahend);
        }
        internal abstract void Subtruct(BaseMatrix<T> minued, BaseMatrix<T> subtrahend);
        public void Subtruct(T scalar) => Subtruct(this, scalar);
        internal abstract void Subtruct(BaseMatrix<T> minued, T subtrahend);
        public void SubtructFromRow(T[] values, int row)
        {
            if (!IsValidForRowSubtruction(values))
                throw MatrixExceptionHelper.Build(new MatrixAndRowCompatibleForSubtruction());

            SubtructFromRow(this, values, row);
        }
        internal abstract void SubtructFromRow(BaseMatrix<T> minued, T[] subtrahend, int row);
        public void SubtructFromRow(T scalar, int row) => SubtructFromRow(this, scalar, row);
        internal abstract void SubtructFromRow(BaseMatrix<T> minued, T scalar, int row);
        public void SubtructFromColumn(T[] values, int column)
        {
            if (!IsValidForColumnSubtruction(values))
                throw MatrixExceptionHelper.Build(new MatrixAndColumnCompatibleForSubtruction());

            SubtructFromColumn(this, values, column);
        }
        internal abstract void SubtructFromColumn(BaseMatrix<T> minued, T[] subtrahend, int column);
        public void SubtructFromColumn(T scalar, int column) => SubtructFromColumn(this, scalar, column);
        internal abstract void SubtructFromColumn(BaseMatrix<T> minued, T scalar, int column);
        #endregion

        #region Multiplication
        public BaseMatrix<T> Multiply(BaseMatrix<T> multiplier)
        {
            if (!IsValidForMultiplication(multiplier))
                throw MatrixExceptionHelper.Build(new MatricesIsNotCompatibleForMultiplication());

            var tmpMatrix = _builder.Like(RowCount, ColumnCount, Multiply(this, multiplier));
            return tmpMatrix;
        }
        internal abstract T[] Multiply(BaseMatrix<T> multiplicand, BaseMatrix<T> multiplier);
        public void Multiply(T scalar) => Multiply(this, scalar);
        internal abstract void Multiply(BaseMatrix<T> multiplicand, T multiplier);
        public void MultiplyRow(T[] values, int row)
        {
            if (!IsValidForRowMultiplication(values))
                throw MatrixExceptionHelper.Build(new MatrixAndRowNotCompatibleForMultiplication());

            MultiplyRow(this, values, row);
        }
        internal abstract void MultiplyRow(BaseMatrix<T> multiplicand, T[] multiplier, int row);
        public void MultiplyRow(T value, int row) => MultiplyRow(this, value, row);
        internal abstract void MultiplyRow(BaseMatrix<T> multiplicand, T value, int row);
        public void MultiplyColumn(T[] values, int column)
        {
            if (!IsValidForColumnMultiplication(values))
                throw MatrixExceptionHelper.Build(new MatrixAndColumnNotCompatibleForMultiplication());

            MultiplyColumn(this, values, column);
        }
        internal abstract void MultiplyColumn(BaseMatrix<T> multiplicand, T[] multiplier, int column);
        public void MultiplyColumn(T value, int column) => MultiplyColumn(this, value, column);
        internal abstract void MultiplyColumn(BaseMatrix<T> multiplicand, T value, int column);
        #endregion

        public void Divide(BaseMatrix<T> multiplier)
        {
            if (!IsValidForDivision(multiplier))
                throw MatrixExceptionHelper.Build(new MatricesIsNotCompatibleForDivison());

            //TODO: Implement
        }
        public void Divide(T scalar) => Divide(this, scalar);
        internal abstract void Divide(BaseMatrix<T> quotiend, T dividend);
        internal abstract void Map(Func<T, T> func);
        internal abstract void Map(Func<T, T, T> func, T[] inputs);
        internal abstract void MapRow(Func<T, T> func, int row);
        internal abstract void MapRow(Func<T, T, T> func, T[] inputs, int row);
        internal abstract void MapColumn(Func<T, T> func, int column);
        internal abstract void MapColumn(Func<T, T, T> func, T[] inputs, int column);
        public void SwapRows(int rowA, int rowB)
        {
            var rowAValues = GetRow(rowA).ToArray();
            var rowBValues = GetRow(rowB).ToArray();

            SetRow(rowBValues, rowA);
            SetRow(rowAValues, rowB);
        }
        public void SwapColumns(int colA, int colB)
        {
            var colAValues = GetColumn(colA).ToArray();
            var colBValues = GetColumn(colB).ToArray();

            SetColumn(colBValues, colA);
            SetColumn(colAValues, colB);
        }

        #region operators
        public static BaseMatrix<T> operator +(BaseMatrix<T> augend, BaseMatrix<T> addend)
        {
            augend.Add(addend);
            return augend;
        }
        #endregion

        #region Validation
        private bool IsValidForAddition(BaseMatrix<T> addend)
        {
            if (addend.RowCount != RowCount || addend.ColumnCount != ColumnCount)
                return false;

            return true;
        }
        private bool IsValidForRowAddition(T[] addend)
        {
            if (addend.Length != ColumnCount)
                return false;

            return true;
        }
        private bool IsValidForColumnAddition(T[] addend)
        {
            if (addend.Length != RowCount)
                return false;

            return true;
        }
        private bool IsValidForSubtruction(BaseMatrix<T> subtrahend)
        {
            return IsValidForAddition(subtrahend);
        }
        private bool IsValidForRowSubtruction(T[] addend)
        {
            if (addend.Length != ColumnCount)
                return false;

            return true;
        }
        private bool IsValidForColumnSubtruction(T[] addend)
        {
            if (addend.Length != RowCount)
                return false;

            return true;
        }
        private bool IsValidForMultiplication(BaseMatrix<T> addend)
        {
            if (addend.ColumnCount != RowCount)
                return false;

            return true;
        }
        private bool IsValidForRowMultiplication(T[] addend)
        {
            if (addend.Length != ColumnCount)
                return false;

            return true;
        }
        private bool IsValidForColumnMultiplication(T[] addend)
        {
            if (addend.Length != RowCount)
                return false;

            return true;
        }
        private bool IsValidForDivision(BaseMatrix<T> addend)
        {
            //TODO: Division is coupled with determinant problem
            return false;
        }
        internal abstract bool IsNonDiagonalAllZeroes();
        #endregion

        public T[] GetValues() => Content.Values.ToArray();
        public IEnumerable<T> GetRow(int row) => Content.GetRow(row);
        public IEnumerable<T> GetColumn(int column) => Content.GetColumn(column);
        public void SetRow(T[] values, int row) => MapRow(new Func<T, T, T>((x, y) => x = y), values, row);
        public void SetColumn(T[] values, int column) => MapColumn(new Func<T, T, T>((x, y) => x = y), values, column);
        public T Get(int row, int column)
        {
            return Content[row, column];
        }
        public void Set(int row, int column, T value)
        {
            Content[row, column] = value;
        }
    }
}
