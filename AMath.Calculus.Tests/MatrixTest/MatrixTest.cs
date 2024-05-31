using AMath.Calculus.Matrices;
using AMath.Calculus.Matrices.Implementation;

namespace AMath.Calculus.Tests.MatrixTest
{
    public partial class MatrixTest
    {
        public Matrix IntegerMatrix { get; set; }


        [SetUp]
        public void Setup()
        {
            IntegerMatrix = new Matrix(new MatrixContent<float>(2, 2, new float[] { 1, 2, 3, 4 }));
        }

        [Test]
        public void Get()
        {
            var result = IntegerMatrix.Get(0, 0);
            Assert.That(result == 1);
        }

        [Test]
        public void Set()
        {
            var matrix = new Matrix(new MatrixContent<float>(2, 2, new float[] { 1, 2, 3, 4 }));
            var row = 0;
            var column = 0;
            var value = 12;

            //Change value
            matrix.Set(row, column, value);

            var result = matrix.Get(row, column);
            Assert.That(result == value);
        }

        [Test]
        public void TransposeMatrix()
        {
            float[] values = new float[] { 1, 2, 3, 4, 5, 6 };
            float[] transposed = new float[] { 1, 4, 2, 5, 3, 6 };

            var matrix = new Matrix(new MatrixContent<float>(3, 2, values));

            matrix.Transpose();

            Assert.That(IsEqual(matrix.GetValues(), transposed));
        }

        [Test]
        public void SwapRows()
        {
            float[] values = new float[] { 1, 2, 3, 4, 5, 6 };
            float[] result = new float[] { 2, 1, 4, 3, 6, 5 };

            var matrix = new Matrix(new MatrixContent<float>(2, 3, values));

            matrix.SwapRows(0, 1);

            Assert.That(IsEqual(matrix.GetValues(), result));
        }

        [Test]
        public void SwapColumn()
        {
            float[] values = new float[] { 1, 2, 3, 4, 5, 6 };
            float[] result = new float[] { 3, 4, 1, 2, 5, 6 };

            var matrix = new Matrix(new MatrixContent<float>(2, 3, values));

            matrix.SwapColumns(0, 1);

            Assert.That(IsEqual(matrix.GetValues(), result));
        }

        [Test]
        public void FalseDiagonalTest()
        {
            float[] values = new float[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var matrix = new Matrix(new MatrixContent<float>(3, 3, values));

            Assert.That(matrix.IsDiagonalMatrix == false);
        }

        [Test]
        public void TrueDiagonalTest()
        {
            float[] values = new float[] { 1, 0, 0, 0, 5, 0, 0, 0, 9 };

            var matrix = new Matrix(new MatrixContent<float>(3, 3, values));

            Assert.That(matrix.IsDiagonalMatrix == true);
        }

        [Test]  
        public void FalseIsSquareMatrix()
        {
            float[] values = new float[] { 1, 0, 0, 0, 5, 0, 0, 0 };

            var matrix = new Matrix(new MatrixContent<float>(2, 4, values));

            Assert.That(matrix.IsSquareMatrix == false);
        }

        [Test]
        public void TrueIsSquareMatrix()
        {
            float[] values = new float[] { 1, 0, 0, 0, 5, 0, 0, 0, 9 };

            var matrix = new Matrix(new MatrixContent<float>(3, 3, values));

            Assert.That(matrix.IsSquareMatrix == true);
        }

        private bool IsEqual(float[] a, float[] b)
        {
            if (a.Length != b.Length)
                return false;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                    return false;
            }

            return true;
        }
    }
}