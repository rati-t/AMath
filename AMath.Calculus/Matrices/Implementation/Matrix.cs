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
        {
            augend.Map(new Func<float, float, float>((x, y) => x + y), addend.Content.Values);
        }

        internal override void Add(BaseMatrix<float> augend, float addend)
        {
            throw new NotImplementedException();
        }

        internal override void Divide(BaseMatrix<float> quotiend, BaseMatrix<float> dividend)
        {
            throw new NotImplementedException();
        }

        internal override void Divide(BaseMatrix<float> quotiend, float dividend)
        {
            throw new NotImplementedException();
        }

        internal override void Map(Func<float, float> func)
        {
            throw new NotImplementedException();
        }

        internal override void Map(Func<float, float, float> func, float[] inputs)
        {
            for (int i = 0; i < inputs.Length; i++)
            {
                func(Content.Values[i], inputs[i]); 
            }
        }

        internal override void Multiply(BaseMatrix<float> multiplicand, BaseMatrix<float> multiplier)
        {
            throw new NotImplementedException();
        }

        internal override void Multiply(BaseMatrix<float> multiplicand, float multiplier)
        {
            throw new NotImplementedException();
        }

        internal override void Subtruct(BaseMatrix<float> minued, BaseMatrix<float> subtrahend)
        {
            throw new NotImplementedException();
        }

        internal override void Subtruct(BaseMatrix<float> minued, float subtrahend)
        {
            throw new NotImplementedException();
        }

        internal override void Transpose(BaseMatrix<float> target)
        {
            throw new NotImplementedException();
        }
    }
}
