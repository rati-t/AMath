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

            for (var i = 0; i < matrixAugend.RowCount; i++)
            {
                for (int j = 0; j < matrixAugend.ColumnCount; j++)
                {
                    Assert.That(sums[matrixAugend.GetIndex(i, j)] == matrixAugend.Get(i, j));
                }
            }
        }

        [Test]
        public void AddVectorToMatrixRow()
        {
            float[] augendValues = new float[] { 1f, 2f, 3f, 4f };
            float[] addendValues = new float[] { 1f, 1f };
            float[] sums = new float[4] { 2f, 2f, 4f, 4f };
            var row = 0;

            var matrixAugend = new Matrix(new MatrixContent<float>(2, 2, augendValues));

            matrixAugend.AddToRow(addendValues, row);

            for (var i = 0; i < matrixAugend.RowCount; i++)
            {
                for (int j = 0; j < matrixAugend.ColumnCount; j++)
                {
                    Assert.That(sums[matrixAugend.GetIndex(i, j)] == matrixAugend.Get(i, j));
                }
            }
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

            for (var i = 0; i < matrixAugend.RowCount; i++)
            {
                for (int j = 0; j < matrixAugend.ColumnCount; j++)
                {
                    Assert.That(sums[matrixAugend.GetIndex(i, j)] == matrixAugend.Get(i, j));
                }
            }
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

            for (var i = 0; i < matrixAugend.RowCount; i++)
            {
                for (int j = 0; j < matrixAugend.ColumnCount; j++)
                {
                    Assert.That(sums[matrixAugend.GetIndex(i, j)] == matrixAugend.Get(i, j));
                }
            }
        }
    }
}
