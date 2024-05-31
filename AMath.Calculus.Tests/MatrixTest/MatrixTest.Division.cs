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
        public void DivideMatrixByScalar()
        {
            float[] augendValues = new float[] { 100f, 200f, 300f, 400f };
            float scalar = 20f;

            float[] sums = new float[augendValues.Length];

            for (int i = 0; i < augendValues.Length; i++)
            {
                sums[i] = augendValues[i] / scalar;
            }

            var matrixAugend = new Matrix(new MatrixContent<float>(2, 2, augendValues));

            matrixAugend.Divide(scalar);

            Assert.That(IsEqual(matrixAugend.GetValues(), sums));
        }
    }
}
