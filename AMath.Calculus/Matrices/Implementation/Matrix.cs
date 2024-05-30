using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMath.Calculus.Matrices.Implementation
{
    public class Matrix : BaseMatrix<float>
    {
        public Matrix(MatrixContent<float> content) : base(content)
        {
            _builder = new MatrixBuilder();
        }

        public Matrix(int rows, int columns) : this(new MatrixContent<float>(rows, columns))
        {
            _builder = new MatrixBuilder();
        }

        internal override void Add(BaseMatrix<float> augend, BaseMatrix<float> addend)
            => augend.Map(new Func<float, float, float>((x, y) => x + y), addend.Content.Values);

        internal override void Add(BaseMatrix<float> augend, float addend)
            => augend.Map(new Func<float, float>(x => x + addend));

        internal override void AddToColumn(BaseMatrix<float> augend, float[] values, int column)
            => augend.MapColumn(new Func<float, float, float>((x, y) => x + y), values, column);

        internal override void AddToColumn(BaseMatrix<float> augend, float addend, int column)
            => augend.MapColumn(new Func<float, float>(x => x + addend), column);

        internal override void AddToRow(BaseMatrix<float> augend, float[] values, int row)
            => augend.MapRow(new Func<float, float, float>((x, y) => x + y), values, row);

        internal override void AddToRow(BaseMatrix<float> augend, float addend, int row)
            => augend.MapRow(new Func<float, float>(x => x + addend), row);

        internal override void Divide(BaseMatrix<float> quotiend, float dividend)
            => quotiend.Map(new Func<float, float>(x => x / dividend));

        internal override bool IsNonDiagonalAllZeroes()
        {
            for (int i = 0; i < Content.Values.Length; i++)
            {
                if (Content.NthRow(i) != Content.NthColumn(i) && Content.Values[i] != 0)
                    return false;
            }
            return true;
        }

        internal override void Map(Func<float, float> func)
        {
            for (int i = 0; i < Content.Values.Length; i++)
            {
                Content.Values[i] = func(Content.Values[i]);
            }
        }

        internal override void Map(Func<float, float, float> func, float[] inputs)
        {
            for (int i = 0; i < Content.Values.Length; i++)
            {
                Content.Values[i] = func(Content.Values[i], inputs[i]);
            }
        }

        internal override void MapColumn(Func<float, float> func, int column)
        {
            for (int i = column * RowCount; i < (column + 1) * RowCount; i++)
            {
                Content.Values[i] = func(Content.Values[i]);
            }
        }

        internal override void MapColumn(Func<float, float, float> func, float[] inputs, int column)
        {

            for (int i = column * RowCount; i < (column + 1) * RowCount; i++)
            {
                Content.Values[i] = func(Content.Values[i], inputs[i % RowCount]);
            }
        }

        internal override void MapRow(Func<float, float> func, int row)
        {
            for (int i = row; i < Content.Values.Length; i += RowCount)
            {
                Content.Values[i] = func(Content.Values[i]);
            }
        }

        internal override void MapRow(Func<float, float, float> func, float[] inputs, int row)
        {
            for (int i = row; i < Content.Values.Length; i += RowCount)
            {
                Content.Values[i] = func(Content.Values[i], inputs[i / RowCount]);
            }
        }

        internal override void Multiply(BaseMatrix<float> multiplicand, BaseMatrix<float> multiplier)
            => multiplicand.Map(new Func<float, float, float>((x, y) => x * y), multiplier.Content.Values);

        internal override void Multiply(BaseMatrix<float> multiplicand, float multiplier)
            => multiplicand.Map(new Func<float, float>(x => x * multiplier));

        internal override void MultiplyColumn(BaseMatrix<float> multiplicand, float[] multiplier, int column)
            => multiplicand.MapColumn(new Func<float, float, float>((x, y) => x * y), multiplier, column);

        internal override void MultiplyColumn(BaseMatrix<float> multiplicand, float value, int column)
            => multiplicand.MapColumn(new Func<float, float>(x => x * value), column);

        internal override void MultiplyRow(BaseMatrix<float> multiplicand, float[] multiplier, int row)
            => multiplicand.MapRow(new Func<float, float, float>((x, y) => x * y), multiplier, row);

        internal override void MultiplyRow(BaseMatrix<float> multiplicand, float value, int row)
            => multiplicand.MapRow(new Func<float, float>(x => x * value), row);

        internal override void Subtruct(BaseMatrix<float> minued, BaseMatrix<float> subtrahend)
            => minued.Map(new Func<float, float, float>((x, y) => x - y), subtrahend.Content.Values);

        internal override void Subtruct(BaseMatrix<float> minued, float subtrahend)
            => minued.Map(new Func<float, float>(x => x - subtrahend));

        internal override void SubtructFromColumn(BaseMatrix<float> minued, float[] subtrahend, int column)
            => minued.MapColumn(new Func<float, float, float>((x, y) => x - y), subtrahend, column);

        internal override void SubtructFromColumn(BaseMatrix<float> minued, float scalar, int column)
            => minued.MapColumn(new Func<float, float>(x => x - scalar), column);

        internal override void SubtructFromRow(BaseMatrix<float> minued, float[] subtrahend, int row)
            => minued.MapRow(new Func<float, float, float>((x, y) => x - y), subtrahend, row);

        internal override void SubtructFromRow(BaseMatrix<float> minued, float scalar, int row)
            => minued.MapRow(new Func<float, float>(x => x - scalar), row);
    }
}
