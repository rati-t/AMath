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

            RowCount = content.RowCount;
            ColumnCount = content.ColumnCount;
            Content = content;
        }

        protected BaseMatrix(int rows, int columns) : this(new MatrixContent<T>(rows, columns))
        {

        }

        public int RowCount { get; private set; }
        public int ColumnCount { get; private set; }

        public int GetIndex(int row, int column) => Content.GetIndex(row, column);
        public (int, int) GetCoordinates(int index) => Content.GetCoordinates(index);


        public void Add(BaseMatrix<T> addend)
        {
            if (!IsValidForAddition(addend))
                throw new MatricesIsNotCompatibleForAddition();

            Add(this, addend);
        }
        public void Add(T scalar) => Add(this, scalar);
        internal abstract void Add(BaseMatrix<T> augend, BaseMatrix<T> addend);
        internal abstract void Add(BaseMatrix<T> augend, T addend);

        public void Subtruct(BaseMatrix<T> subtrahend)
        {
            if (!IsValidForAddition(subtrahend))
                throw new MatricesIsNotCompatibleForSubtruction();

            Subtruct(this, subtrahend);
        }
        public void Subtruct(T scalar) => Subtruct(this, scalar);
        internal abstract void Subtruct(BaseMatrix<T> minued, BaseMatrix<T> subtrahend);
        internal abstract void Subtruct(BaseMatrix<T> minued, T subtrahend);

        public void Multiply(BaseMatrix<T> multiplier)
        {
            if (!IsValidForMultiplication(multiplier))
                throw new MatricesIsNotCompatibleForMultiplication();

            Multiply(this, multiplier);
        }
        public void Multiply(T scalar) => Multiply(this, scalar);
        internal abstract void Multiply(BaseMatrix<T> multiplicand, BaseMatrix<T> multiplier);
        internal abstract void Multiply(BaseMatrix<T> multiplicand, T multiplier);

        
        public void Divide(BaseMatrix<T> multiplier)
        {
            if (!IsValidForDivision(multiplier))
                throw new MatricesIsNotCompatibleForMultiplication();

            //TODO: Implement
        }
        public void Divide(T scalar) => Divide(this, scalar);
        internal abstract void Divide(BaseMatrix<T> quotiend, T dividend);

        internal abstract void Transpose(BaseMatrix<T> target);
        internal abstract void Map(Func<T, T> func);
        internal abstract void Map(Func<T, T, T> func, T[] inputs);

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
        public bool IsValidForSubtruction(BaseMatrix<T> subtrahend)
        {
            return IsValidForAddition(subtrahend);
        }

        public bool IsValidForMultiplication(BaseMatrix<T> addend)
        {
            if (addend.RowCount != ColumnCount)
                return false;

            return true;
        }

        public bool IsValidForDivision(BaseMatrix<T> addend)
        {
            //TODO: Division is coupled with determinant problem
            return false;
        }
        #endregion

        #region Abstract
        public virtual T Get(int row, int column)
        {
            return Content[row, column];
        }
        public virtual void Set(int row, int column, T value)
        {
            Content[row, column] = value;
        }
        #endregion
    }
}
