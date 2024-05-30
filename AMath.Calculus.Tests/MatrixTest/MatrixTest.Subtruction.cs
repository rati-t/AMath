using AMath.Calculus.Matrices;
using AMath.Calculus.Matrices.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMath.Calculus.Tests.MatrixTest
{
    public partial class MatrixTest
    {
        [Test]
        public void SubtructMatrices()
        {
            float[] minuedValues = new float[] { 1f, 2f, 3f, 4f };
            float[] subtrahendValues = new float[] { 1f, 1f, 1f, 1f };

            float[] sums = new float[minuedValues.Length];

            for (int i = 0; i < minuedValues.Length; i++)
            {
                sums[i] = minuedValues[i] - subtrahendValues[i];
            }

            var matrixMinued = new Matrix(new MatrixContent<float>(2, 2, minuedValues));
            var matrixSubtrahend = new Matrix(new MatrixContent<float>(2, 2, subtrahendValues));

            matrixMinued.Subtruct(matrixSubtrahend);

            for (var i = 0; i < matrixMinued.RowCount; i++)
            {
                for (int j = 0; j < matrixMinued.ColumnCount; j++)
                {
                    Assert.That(sums[matrixMinued.GetIndex(i, j)] == matrixMinued.Get(i, j));
                }
            }
        }

        [Test]
        public void SubtructVectorFromMatrixRow()
        {
            float[] minuedValues = new float[] { 1f, 2f, 3f, 4f };
            float[] subtrahendValues = new float[] { 1f, 1f };
            float[] result = new float[4] { 0f, 2f, 2f, 4f };
            var row = 0;

            var matrixMinued = new Matrix(new MatrixContent<float>(2, 2, minuedValues));

            matrixMinued.SubtructFromRow(subtrahendValues, row);

            for (var i = 0; i < matrixMinued.RowCount; i++)
            {
                for (int j = 0; j < matrixMinued.ColumnCount; j++)
                {
                    Assert.That(result[matrixMinued.GetIndex(i, j)] == matrixMinued.Get(i, j));
                }
            }
        }

        [Test]
        public void SubtructScalarOfMatrix()
        {
            float[] minuedValues = new float[] { 1f, 2f, 3f, 4f };
            float scalar = 4f;

            float[] result = new float[minuedValues.Length];

            for (int i = 0; i < minuedValues.Length; i++)
            {
                result[i] = minuedValues[i] - scalar;
            }

            var matrixMinued = new Matrix(new MatrixContent<float>(2, 2, minuedValues));

            matrixMinued.Subtruct(scalar);

            for (var i = 0; i < matrixMinued.RowCount; i++)
            {
                for (int j = 0; j < matrixMinued.ColumnCount; j++)
                {
                    Assert.That(result[matrixMinued.GetIndex(i, j)] == matrixMinued.Get(i, j));
                }
            }
        }

        [Test]
        public void SubtructScalarFromMatrixRow()
        {
            float[] minuedValues = new float[] { 1f, 2f, 3f, 4f };
            float scalar = 4f;
            float[] result = new float[4] { -3f, 2f, -1f, 4f};
            int row = 0;

            var matrixMinued = new Matrix(new MatrixContent<float>(2, 2, minuedValues));

            matrixMinued.SubtructFromRow(scalar, row);

            for (var i = 0; i < matrixMinued.RowCount; i++)
            {
                for (int j = 0; j < matrixMinued.ColumnCount; j++)
                {
                    Assert.That(result[matrixMinued.GetIndex(i, j)] == matrixMinued.Get(i, j));
                }
            }
        }
    }
}
