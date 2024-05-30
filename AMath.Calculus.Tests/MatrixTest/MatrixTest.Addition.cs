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
        public void AddMatrices()
        {
            float[] augendValues = new float[] { 1f, 2f, 3f, 4f };
            float[] addendValues = new float[] { 1f, 1f, 1f, 1f };

            float[] sums = new float[augendValues.Length];

            for (int i = 0; i < augendValues.Length; i++)
            {
                sums[i] = augendValues[i] + addendValues[i];
            }

            var matrixAugend = new Matrix(new MatrixContent<float>(2, 2, augendValues));
            var matrixAddend = new Matrix(new MatrixContent<float>(2, 2, addendValues));

            matrixAugend.Add(matrixAddend);

            Assert.That(IsEqual(matrixAugend.GetValues(), sums));
        }

        [Test]
        public void AddScalarToMatrix()
        {
            float[] augendValues = new float[] { 1f, 2f, 3f, 4f };
            float scalar = 4f;

            float[] sums = new float[augendValues.Length];

            for (int i = 0; i < augendValues.Length; i++)
            {
                sums[i] = augendValues[i] + scalar;
            }

            var matrixAugend = new Matrix(new MatrixContent<float>(2, 2, augendValues));

            matrixAugend.Add(scalar);

            Assert.That(IsEqual(matrixAugend.GetValues(), sums));
        }

        [Test]
        public void AddRowToMatrixRow()
        {
            float[] augendValues = new float[] { 1f, 2f, 3f, 4f };
            float[] addendValues = new float[] { 1f, 1f };
            float[] sums = new float[4] { 2f, 2f, 4f, 4f };
            var row = 0;

            var matrixAugend = new Matrix(new MatrixContent<float>(2, 2, augendValues));

            matrixAugend.AddToRow(addendValues, row);

            Assert.That(IsEqual(matrixAugend.GetValues(), sums));
        }

        [Test]
        public void AddScalarToMatrixRow()
        {
            float[] augendValues = new float[] { 1f, 2f, 3f, 4f };
            float scalar = 4f;
            float[] sums = new float[] { 5f, 2f, 7f, 4f };
            int row = 0;

            var matrixAugend = new Matrix(new MatrixContent<float>(2, 2, augendValues));

            matrixAugend.AddToRow(scalar, row);

            Assert.That(IsEqual(matrixAugend.GetValues(), sums));
        }

        [Test]
        public void AddColumnToMatrixColumn()
        {
            float[] augendValues = new float[] { 1f, 2f, 3f, 4f };
            float[] addendValues = new float[] { 1f, 1f };
            float[] sums = new float[4] { 2f, 3f, 3f, 4f };
            var column = 0;

            var matrixAugend = new Matrix(new MatrixContent<float>(2, 2, augendValues));

            matrixAugend.AddToColumn(addendValues, column);

            Assert.That(IsEqual(matrixAugend.GetValues(), sums));
        }

        [Test]
        public void AddScalarToMatrixColumn()
        {
            float[] augendValues = new float[] { 1f, 2f, 3f, 4f };
            float scalar = 4f;
            float[] sums = new float[] { 5f, 6f, 3f, 4f };
            int column = 0;

            var matrixAugend = new Matrix(new MatrixContent<float>(2, 2, augendValues));

            matrixAugend.AddToColumn(scalar, column);

            Assert.That(IsEqual(matrixAugend.GetValues(), sums));
        }
    }
}
