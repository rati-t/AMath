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
        public void Add()
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
    }
}