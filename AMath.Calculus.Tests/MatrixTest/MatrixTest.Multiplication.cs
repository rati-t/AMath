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
        // TO DO: Multplication of matrices with differrent dimensions
        //[Test]
        //public void MultiplyMatrices()
        //{
        //    float[] multiplicandValues = new float[] { 1f, 2f, 3f, 4f };
        //    float[] multiplierValues = new float[] { 10f, 12f, 13f, 15f };

        //    float[] result = new float[multiplicandValues.Length];

        //    for (int i = 0; i < multiplicandValues.Length; i++)
        //    {
        //        result[i] = multiplicandValues[i] * multiplierValues[i];
        //    }

        //    var matrixMultiplicand = new Matrix(new MatrixContent<float>(2, 2, multiplicandValues));
        //    var matrixMultiplier = new Matrix(new MatrixContent<float>(2, 2, multiplierValues));

        //    matrixMultiplicand.Multiply(matrixMultiplier);

        //    Assert.That(IsEqual(matrixMultiplicand.GetValues(), result));
        //}

        [Test]
        public void MultiplyMatrixByScalar()
        {
            float[] multiplicandValues = new float[] { 1f, 2f, 3f, 4f };
            float scalar = 35f;

            float[] result = new float[multiplicandValues.Length];

            for (int i = 0; i < multiplicandValues.Length; i++)
            {
                result[i] = multiplicandValues[i] * scalar;
            }

            var matrixAugend = new Matrix(new MatrixContent<float>(2, 2, multiplicandValues));

            matrixAugend.Multiply(scalar);

            Assert.That(IsEqual(matrixAugend.GetValues(), result));
        }


        [Test]
        public void MultiplyMatrixRowByRow()
        {
            float[] multiplicandValues = new float[] { 1f, 2f, 3f, 4f, 5f, 7f };
            float[] multiplierValues = new float[] { 9f, 3f, 105f };
            float[] result = new float[6] { 9f, 2f, 9f, 4f, 525f, 7f };
            var row = 0;

            var matrixMultiplicand = new Matrix(new MatrixContent<float>(2, 3, multiplicandValues));

            matrixMultiplicand.MultiplyRow(multiplierValues, row);

            Assert.That(IsEqual(matrixMultiplicand.GetValues(), result));
        }

        [Test]
        public void MultiplyMatrixRowByScalar()
        {
            float[] multiplicandValues = new float[] { 1f, 2f, 3f, 4f };
            float scalar = 35f;
            float[] result = new float[4] { 35f, 2f, 105f, 4f };
            int row = 0;

            var matrixAugend = new Matrix(new MatrixContent<float>(2, 2, multiplicandValues));

            matrixAugend.MultiplyRow(scalar, row);

            Assert.That(IsEqual(matrixAugend.GetValues(), result));
        }

        [Test]
        public void MultiplyMatrixColumnByColumn()
        {
            float[] multiplicandValues = new float[] { 1f, 2f, 3f, 4f, 5f, 7f };
            float[] multiplierValues = new float[] { 9f, 3f, 105f };
            float[] result = new float[6] { 9f, 6f, 315f, 4f, 5f, 7f };
            var Column = 0;

            var matrixMultiplicand = new Matrix(new MatrixContent<float>(3, 2, multiplicandValues));

            matrixMultiplicand.MultiplyColumn(multiplierValues, Column);

            Assert.That(IsEqual(matrixMultiplicand.GetValues(), result));
        }

        [Test]
        public void MultiplyMatrixColumnByScalar()
        {
            float[] multiplicandValues = new float[] { 1f, 2f, 3f, 4f };
            float scalar = 35f;
            float[] result = new float[4] { 35f, 70f, 3f, 4f };
            int Column = 0;

            var matrixAugend = new Matrix(new MatrixContent<float>(2, 2, multiplicandValues));

            matrixAugend.MultiplyColumn(scalar, Column);

            Assert.That(IsEqual(matrixAugend.GetValues(), result));
        }
    }
}
