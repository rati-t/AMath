using AMath.Calculus.Matrices;
using AMath.Calculus.Matrices.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMath.Algorithms.Tests
{
    public class BellmanTests
    {
        private Matrix Graph { get; set; }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestB()
        {
            try
            {
                Graph = new Matrix(new MatrixContent<float>(6, 6, new float[]
                {
                0, 5, 0, 0, 0, 0,
                0, 0, 1, 2, 0, 0,
                0, 0, 0, 0, 1, 0,
                0, 0, 0, 0, 0, 2,
                0, 0, 0, -1, 0, 0,
                0, 0, 0, 0, -3, 0,
                }));

                var expectedOutput = new List<int>() { 0, 1, 3 };
                Bellman.ShortestPath(Graph, 0, 4);
            }
            catch (Exception ex)
            {
                Assert.That(ex is NegativeCycleException);
            }
        }

        [Test]
        public void TestC()
        {
            Graph = new Matrix(new MatrixContent<float>(5, 5, new float[]
            {
                0, 2, 0, 0,  0,
                0, 0, 3, 0,  0,
                0, 0, 0, -1, 0,
                0, 0, 0, 0,  3,
                0, 0, 1, 0,  0
            }));

            var expectedOutput = new List<int>() { 2, 3, 4 };
            Bellman.ShortestPath(Graph, 1, 4);
            Assert.That(expectedOutput.SequenceEqual(expectedOutput));
        }

        [Test]
        public void TestD()
        {
            Graph = new Matrix(new MatrixContent<float>(6, 6, new float[]
            {
                0, 6, 4, 5, 0, 0,
                0, 0, 0, 0, -1, 0,
                0, -2, 0, 0, 3, 0,
                0, 0, -2, 0, 0, -1,
                0, 0, 0, 0, 0, 3,
                0, 0, 0, 0, 0, 0
            }));

            var expectedOutput = new List<int>() { 1, 3, 2, 1, 4, 5 };
            Bellman.ShortestPath(Graph, 0, 5);
            Assert.That(expectedOutput.SequenceEqual(expectedOutput));
        }


        [Test]
        public void TestPresentationBellmanGraphNegativeCycle()
        {
            var matrixInput = new Matrix(new MatrixContent<float>(6, 6, new float[]
            {
                0, 5, 0, 0, 0, 0,
                0, 0, 1, 2, 0, 0,
                0, 0, 0, 0, 1, 0,
                0, 0, 0, 0, 0, 2,
                0, 0, 0, -1, 0, 0,
                0, 0, 0, 0, -3, 0
            }));

            var result = Assert.Throws<NegativeCycleException>( () => Bellman.ShortestPath(matrixInput, 3, 5));
        }

        [Test]
        public void TestPresentationBellman()
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

            var expectedOutput = new List<int>() { 4, 2, 1, 5 };
            var output = Bellman.ShortestPath(matrixInput, 3, 5);
            Assert.That(expectedOutput.SequenceEqual(output));
        }
    }
}

