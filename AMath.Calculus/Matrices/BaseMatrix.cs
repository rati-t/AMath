using AMath.Calculus.Matrices.Implementation;
using System;
using System.Collections.Generic;
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

        protected BaseMatrix(int rows, int columns) : this(new MatrixContent<T>(rows, columns))
        {

        }

        public int RowCount { get { return Content.RowCount; } }
        public int ColumnCount { get { return Content.ColumnCount; } }

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
            if (!IsValidForAddition(values))
                throw MatrixExceptionHelper.Build(new MatrixAndVectorNotCompatibleForAddition());

            AddToRow(this, values, row);
        }
        internal abstract void AddToRow(BaseMatrix<T> augend, T[] values, int row);

        public void AddToRow(T scalar, int row) => AddToRow(this, scalar, row);
        internal abstract void AddToRow(BaseMatrix<T> augend, T addend, int row);
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
            if (!IsValidForSubtruction(values))
                throw MatrixExceptionHelper.Build(new MatrixAndVectorNotCompatibleForSubtruction());

            SubtructFromRow(this, values, row);
        }
        internal abstract void SubtructFromRow(BaseMatrix<T> minued, T[] subtrahend, int row);

        public void SubtructFromRow(T scalar, int row) => SubtructFromRow(this, scalar, row);
        internal abstract void SubtructFromRow(BaseMatrix<T> minued, T scalar, int row);
        #endregion

        #region Multiplication
        public void Multiply(BaseMatrix<T> multiplier)
        {
            if (!IsValidForMultiplication(multiplier))
                throw MatrixExceptionHelper.Build(new MatricesIsNotCompatibleForMultiplication());

            Multiply(this, multiplier);
        }
        internal abstract void Multiply(BaseMatrix<T> multiplicand, BaseMatrix<T> multiplier);

        public void Multiply(T scalar) => Multiply(this, scalar);
        internal abstract void Multiply(BaseMatrix<T> multiplicand, T multiplier);

        public void MultiplyRow(T[] values, int row)
        {
            if (!IsValidForMultiplication(values))
                throw MatrixExceptionHelper.Build(new MatrixAndVectorNotCompatibleForMultiplication());

            MultiplyRow(this, values, row);
        }
        internal abstract void MultiplyRow(BaseMatrix<T> multiplicand, T[] multiplier, int row);

        public void MultiplyRow(T value, int row) => MultiplyRow(this, value, row);
        internal abstract void MultiplyRow(BaseMatrix<T> multiplicand, T value, int row);
        #endregion

        public void Divide(BaseMatrix<T> multiplier)
        {
            if (!IsValidForDivision(multiplier))
                throw MatrixExceptionHelper.Build(new MatricesIsNotCompatibleForMultiplication());

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
            var colAValues = GetRow(colA).ToArray();
            var colBValues = GetRow(colB).ToArray();

            SetRow(colBValues, colA);
            SetRow(colAValues, colB);
        }

        #region operators
        public static BaseMatrix<T> operator +(BaseMatrix<T> augend, BaseMatrix<T> addend)
        {
            augend.Add(addend);
            return augend;
        }

        #endregion

        #region Validation
        public bool IsValidForAddition(BaseMatrix<T> addend)
        {
            if (addend.RowCount != RowCount || addend.ColumnCount != ColumnCount)
                return false;

            return true;
        }
        public bool IsValidForAddition(T[] addend)
        {
            if (addend.Length != ColumnCount)
                return false;

            return true;
        }
        public bool IsValidForSubtruction(BaseMatrix<T> subtrahend)
        {
            return IsValidForAddition(subtrahend);
        }
        public bool IsValidForSubtruction(T[] addend)
        {
            if (addend.Length != ColumnCount)
                return false;

            return true;
        }

        public bool IsValidForMultiplication(BaseMatrix<T> addend)
        {
            if (addend.RowCount != ColumnCount)
                return false;

            return true;
        }
        public bool IsValidForMultiplication(T[] addend)
        {
            if (addend.Length != ColumnCount)
                return false;

            return true;
        }

        public bool IsValidForDivision(BaseMatrix<T> addend)
        {
            //TODO: Division is coupled with determinant problem
            return false;
        }
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
