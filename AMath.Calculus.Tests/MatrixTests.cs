using AMath.Calculus.Matrix;

namespace AMath.Calculus.Tests
{
    public class MatrixTests
    {
        public Matrix<int> IntegerMatrix { get; set; }


        [SetUp]
        public void Setup()
        {
            IntegerMatrix = new Matrix<int>(new MatrixContent<int>(2, 2, new int[] {1, 2, 3, 4}));
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
            var matrix = new Matrix<int>(new MatrixContent<int>(2, 2, new int[] { 1, 2, 3, 4 }));
            var row = 0;
            var column = 0;
            var value = 12;

            //Change value
            matrix.Set(row, column, value);

            var result = matrix.Get(row, column);
            Assert.That(result == value);
        }
    }
}