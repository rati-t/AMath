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
    public abstract class IMatrix<T>
        where T : struct, IEquatable<T>
    {
        internal IMatrixBuilder<T> _builder;
        internal MatrixContent<T> Content { get; set; }
        public IMatrix(MatrixContent<T> content)
        {
            if (content == null)
                throw new ArgumentNullException(nameof(content));

            // TODO: Check if dimension match, if not so throw exception

            RowCount = content.RowCount;
            ColumnCount = content.ColumnCount;
            Content = content;
        }

        protected IMatrix(int rows, int columns) : this(new MatrixContent<T>(rows, columns))
        {

        }

        public int RowCount { get; private set; }
        public int ColumnCount { get; private set; }

        public void Add(IMatrix<T> addend)
        {
            if (IsValidForAddition(addend))
                throw new MatricesIsNotCompatibleForAddition();

            Add(this, addend);
        }

        internal abstract void Add(IMatrix<T> augend, IMatrix<T> addend);
        internal abstract void Add(IMatrix<T> augend, T addend);
        internal abstract void Subtruct(IMatrix<T> minued, IMatrix<T> subtrahend);
        internal abstract void Subtruct(IMatrix<T> minued, T subtrahend);
        internal abstract void Multiply(IMatrix<T> multiplicand, IMatrix<T> multiplier);
        internal abstract void Multiply(IMatrix<T> multiplicand, T multiplier);
        internal abstract void Divide(IMatrix<T> quotiend, IMatrix<T> dividend);
        internal abstract void Divide(IMatrix<T> quotiend, T dividend);
        internal abstract void Transpose(IMatrix<T> target);
        internal abstract void Map(Func<T, T> func);
        internal abstract void Map(Func<T, T, T> func, T[] inputs);

        #region operators
        public static IMatrix<T> operator +(IMatrix<T> augend, IMatrix<T> addend)
        {
            return augend.Add(addend);
        }

        #endregion

        #region Validation
        public bool IsValidForAddition(IMatrix<T> addend)
        {
            if (addend.RowCount != RowCount || addend.ColumnCount != ColumnCount)
                return false;

            return true;
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
