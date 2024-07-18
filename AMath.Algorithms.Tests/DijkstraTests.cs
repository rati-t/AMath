using Algorithm.Algorithms;
using AMath.Calculus.Matrices;
using AMath.Calculus.Matrices.Implementation;
using NUnit.Framework.Constraints;

namespace AMath.Algorithms.Tests
{
    public partial class DijkstraTests
    {
        private Matrix Graph { get; set; }
        [SetUp]
        public void Setup()
        {
            Graph = new Matrix(new MatrixContent<float>(5, 5, new float[]
            {
                0, 2, 0, 0, 6,
                2, 0, 2, 4, 3,
                0, 2, 0, 5, 1,
                0, 4, 5, 0, 5,
                6, 3, 1, 5, 0
            }));

        }

        

        [Test]
        public void WhenMatrixIsNotSquare()
        {
            try
            {
                var result = Dijkstra.ShortestPath(new Matrix(new MatrixContent<float>(2, 3, new float[] { 0, 0, 0, 0, 0, 0 })), 0, 0);
            }
            catch (Exception ex)
            {
                Assert.That(ex is Exception);
            }
        }

        [Test]
        public void SourceIsDestination()
        {
            var result = Dijkstra.ShortestPath(Graph, 0, 0);
            Assert.That(result.Count == 0);
        }

        [Test]
        public void TestA()
        {
            var expectedOutput = new List<int>() { 0, 1, 3 };
            var result = Dijkstra.ShortestPath(Graph, 0, 3);
            Assert.That(expectedOutput.SequenceEqual(result));
        }

        [Test]
        public void TestB()
        {
            var expectedOutput = new List<int>() { 1, 4 };
            var result = Dijkstra.ShortestPath(Graph, 1, 4);
            Assert.That(expectedOutput.SequenceEqual(result));
        }

        

        [Test]
        public void TestPresentationDijkstraGraph()
        {
            var matrixInput = new Matrix(new MatrixContent<float>(7, 7, new float[]
            {
                0, 0, 3, 4, 4, 0, 0,
                0, 0, 2, 0, 0, 2, 0,
                3, 2, 0, 0, 4, 0, 0,
                4, 0, 0, 0, 2, 0, 0,
                4, 0, 4, 2, 0, 0, 0,
                0, 2, 5, 0, 0, 0, 5,
                0, 0, 5, 0, 5, 5, 0
            }));

            var expectedOutput = new List<int>() { 3, 4, 2, 1, 5 };
            var result = Dijkstra.ShortestPath(matrixInput, 3, 5);
            Assert.That(expectedOutput.SequenceEqual(result));
        }
    }
}