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

            Assert.That(IsEqual(matrixMinued.GetValues(), sums));
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

            Assert.That(IsEqual(matrixMinued.GetValues(), result));
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

            Assert.That(IsEqual(matrixMinued.GetValues(), result));
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

            Assert.That(IsEqual(matrixMinued.GetValues(), result));
        }

        [Test]
        public void SubtructVectorFromMatrixColumn()
        {
            float[] minuedValues = new float[] { 1f, 2f, 3f, 4f };
            float[] subtrahendValues = new float[] { 1f, 1f };
            float[] result = new float[4] { 0f, 1f, 3f, 4f };
            var column = 0;

            var matrixMinued = new Matrix(new MatrixContent<float>(2, 2, minuedValues));

            matrixMinued.SubtructFromColumn(subtrahendValues, column);

            Assert.That(IsEqual(matrixMinued.GetValues(), result));
        }


        [Test]
        public void SubtructScalarFromMatrixColumn()
        {
            float[] minuedValues = new float[] { 1f, 2f, 3f, 4f };
            float scalar = 4f;
            float[] result = new float[4] { -3f, -2f, 3f, 4f };
            int column = 0;

            var matrixMinued = new Matrix(new MatrixContent<float>(2, 2, minuedValues));

            matrixMinued.SubtructFromColumn(scalar, column);

            Assert.That(IsEqual(matrixMinued.GetValues(), result));
        }
    }
}
