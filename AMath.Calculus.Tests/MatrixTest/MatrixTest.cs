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

        [Test]
        public void MinorTest()
        {
            float[] values = new float[] { 1, 2, 3,
                                            4, 5, 6,
                                            7, 8, 9 };
            float[] expected = new float[] { 5, 6, 8, 9 };
            var matrix = new MatrixBuilder().Like(3, 3, values);
            Assert.That(IsEqual(matrix.GetMinor(0, 0).GetValues(), expected));
        }

        [Test]
        public void DeterminantTest()
        {
            float[] values = new float[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var matrix = new MatrixBuilder().Like(3, 3, values);
            Assert.That(matrix.GetDeterminant() == 0);
        }

        [Test]
        public void DeterminantTestB()
        {
            float[] values = new float[] { 4, 3, 4, 0, 9, 4, 5, 2, 4, 1, 2, 4, 4, 1, 9, 5, 2, 8, 8, 5, 10, 5, 1, 1, 7, 10, 3, 3, 2, 5, 8, 9, 8, 6, 3, 4, 1, 2, 5, 9, 4, 4, 5, 0, 4, 0, 8, 10, 7, 5, 4, 3, 9, 7, 3, 6, 8, 9, 10, 1, 4, 9, 4, 0 };
            var matrix = new MatrixBuilder().Like(8, 8, values);
            var det = matrix.GetDeterminant();
            Assert.That(det == 5083515);
        }

        [Test]
        public void DeterminantTestC()
        {
            float[] values = new float[] { 3, 2, -1, 4, 2, 1, 5, 7, 0, 5, 2, -6, -1, 2, 1, 0 };
            var matrix = new MatrixBuilder().Like(4, 4, values);
            var det = matrix.GetDeterminant();
            Assert.That(det == -418);
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