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


        internal override void Divide(BaseMatrix<float> quotiend, float dividend)
            => quotiend.Map(new Func<float, float>(x => x / dividend));

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

        internal override void Multiply(BaseMatrix<float> multiplicand, BaseMatrix<float> multiplier)
            => multiplicand.Map(new Func<float, float, float>((x, y) => x * y), multiplier.Content.Values);

        internal override void Multiply(BaseMatrix<float> multiplicand, float multiplier)
            => multiplicand.Map(new Func<float, float>(x => x * multiplier));

        internal override void Subtruct(BaseMatrix<float> minued, BaseMatrix<float> subtrahend)
            => minued.Map(new Func<float, float, float>((x, y) => x - y), subtrahend.Content.Values);

        internal override void Subtruct(BaseMatrix<float> minued, float subtrahend)
            => minued.Map(new Func<float, float>(x => x - subtrahend));

        internal override void Transpose(BaseMatrix<float> target)
        {
            throw new NotImplementedException();
        }
    }
}
