using AMath.Calculus.Matrices;
using AMath.Calculus.Matrices.Implementation;

namespace AMath.Calculus.Tests.MatrixTest
{
    public partial class MatrixTests
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

            for (int i = 0; i < matrix.RowCount; i++)
            {
                for (int j = 0; j < matrix.ColumnCount; j++)
                {
                    Assert.That(matrix.Get(i, j) == transposed[matrix.GetIndex(i, j)]);
                }
            }
        }

        [Test]
        public void SwapRows()
        {
            float[] values = new float[] { 1, 2, 3, 4, 5, 6 };
            float[] result = new float[] { 2, 4, 6, 1, 3, 5 };

            var matrix = new Matrix(new MatrixContent<float>(3, 2, values));

            matrix.SwapRows(0, 1);

            Assert.That(IsEqual(matrix.GetValues(), result));
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