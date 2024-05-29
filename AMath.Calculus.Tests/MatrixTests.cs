using AMath.Calculus.Matrices;
using AMath.Calculus.Matrices.Implementation;

namespace AMath.Calculus.Tests
{
    public class MatrixTests
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
                    Assert.That(sums[matrixAugend.GetIndex(i,j)] == matrixAugend.Get(i, j));
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
        public void SubtructMatrices()
        {
            float[] augendValues = new float[] { 1f, 2f, 3f, 4f };
            float[] addendValues = new float[] { 1f, 1f, 1f, 1f };

            float[] sums = new float[augendValues.Length];

            for (int i = 0; i < augendValues.Length; i++)
            {
                sums[i] = augendValues[i] - addendValues[i];
            }

            var matrixAugend = new Matrix(new MatrixContent<float>(2, 2, augendValues));
            var matrixAddend = new Matrix(new MatrixContent<float>(2, 2, addendValues));

            matrixAugend.Subtruct(matrixAddend);

            for (var i = 0; i < matrixAugend.RowCount; i++)
            {
                for (int j = 0; j < matrixAugend.ColumnCount; j++)
                {
                    Assert.That(sums[matrixAugend.GetIndex(i, j)] == matrixAugend.Get(i, j));
                }
            }
        }

        [Test]
        public void SubtructScalarOfMatrix()
        {
            float[] augendValues = new float[] { 1f, 2f, 3f, 4f };
            float scalar = 4f;

            float[] sums = new float[augendValues.Length];

            for (int i = 0; i < augendValues.Length; i++)
            {
                sums[i] = augendValues[i] - scalar;
            }

            var matrixAugend = new Matrix(new MatrixContent<float>(2, 2, augendValues));

            matrixAugend.Subtruct(scalar);

            for (var i = 0; i < matrixAugend.RowCount; i++)
            {
                for (int j = 0; j < matrixAugend.ColumnCount; j++)
                {
                    Assert.That(sums[matrixAugend.GetIndex(i, j)] == matrixAugend.Get(i, j));
                }
            }
        }

        // TO DO: Multplication of matrices with differrent dimensions
        [Test]
        public void MultiplyMatrices()
        {
            float[] augendValues = new float[] { 1f, 2f, 3f, 4f };
            float[] addendValues = new float[] { 10f, 12f, 13f, 15f };

            float[] sums = new float[augendValues.Length];

            for (int i = 0; i < augendValues.Length; i++)
            {
                sums[i] = augendValues[i] * addendValues[i];
            }

            var matrixAugend = new Matrix(new MatrixContent<float>(2, 2, augendValues));
            var matrixAddend = new Matrix(new MatrixContent<float>(2, 2, addendValues));

            matrixAugend.Multiply(matrixAddend);

            for (var i = 0; i < matrixAugend.RowCount; i++)
            {
                for (int j = 0; j < matrixAugend.ColumnCount; j++)
                {
                    Assert.That(sums[matrixAugend.GetIndex(i, j)] == matrixAugend.Get(i, j));
                }
            }
        }


        [Test]
        public void MultiplyMatrixByScalar()
        {
            float[] augendValues = new float[] { 1f, 2f, 3f, 4f };
            float scalar = 35f;

            float[] sums = new float[augendValues.Length];

            for (int i = 0; i < augendValues.Length; i++)
            {
                sums[i] = augendValues[i] * scalar;
            }

            var matrixAugend = new Matrix(new MatrixContent<float>(2, 2, augendValues));

            matrixAugend.Multiply(scalar);

            for (var i = 0; i < matrixAugend.RowCount; i++)
            {
                for (int j = 0; j < matrixAugend.ColumnCount; j++)
                {
                    Assert.That(sums[matrixAugend.GetIndex(i, j)] == matrixAugend.Get(i, j));
                }
            }
        }

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