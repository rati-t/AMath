using Algorithm.Algorithms;
using AMath.Calculus.Matrices;
using AMath.Calculus.Matrices.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Algorithm.Algorithms.AStar;

namespace AMath.Algorithms.Tests
{
    public class AStarTests
    {
        private int[,] Grid1 { get; set; }
        private int[,] Grid2 { get; set; }
        private int[,] Grid3 { get; set; }
        private int[,] BlokedGrid { get; set; }
        [SetUp]
        public void Setup()
        {
            Grid1 = new int[,] 
            {
                {1, 0, 1, 1, 1, 1, 0, 1, 1, 1},
                {1, 1, 1, 0, 1, 1, 1, 0, 1, 1},
                {1, 1, 1, 0, 1, 1, 0, 1, 0, 1},
                {0, 0, 1, 0, 1, 0, 0, 0, 0, 1},
                {1, 1, 1, 0, 1, 1, 1, 0, 1, 0},
                {1, 0, 1, 1, 1, 1, 0, 1, 0, 0},
                {1, 0, 0, 0, 0, 1, 0, 0, 0, 1},
                {1, 0, 1, 1, 1, 1, 0, 1, 1, 1},
                {1, 1, 1, 0, 0, 0, 1, 0, 0, 1}
            };
            Grid2 = new int[,]
            {
                {1, 1, 1, 1, 1},
                {0, 1, 0, 0, 1},
                {1, 1, 1, 0, 1},
                {1, 0, 1, 1, 1},
                {1, 1, 1, 0, 1}
            };
            Grid3 = new int[,]
            {
                {1, 0, 1, 1, 1, 1, 0, 1, 1, 1},
                {1, 1, 1, 0, 1, 1, 1, 0, 1, 1},
                {1, 1, 1, 0, 1, 1, 0, 1, 0, 1},
                {0, 0, 1, 0, 1, 0, 0, 0, 0, 1},
                {1, 1, 1, 0, 1, 1, 1, 0, 1, 0},
                {1, 0, 1, 1, 1, 1, 0, 1, 0, 0},
                {1, 0, 0, 0, 0, 1, 0, 0, 0, 1},
                {1, 0, 1, 1, 1, 1, 0, 1, 1, 1},
                {1, 1, 1, 0, 0, 0, 1, 0, 0, 1}
            };
            BlokedGrid = new int[,]
            {
                {1, 0, 1, 0, 1},
                {0, 1, 0, 1, 0},
                {1, 0, 1, 0, 1},
                {0, 0, 0, 1, 0},
                {1, 0, 1, 0, 1}
            };
        }

        [Test]
        public void TestStar1()
        {
            try
            {
                List<Point> expectedResult = new List<Point>() { new Point(8, 0), new Point(7, 0), new Point(6, 0), new Point(5, 0), new Point(4, 1), 
                    new Point(3, 2), new Point(2, 1), new Point(1, 0), new Point(0, 0)};
                var result = FindPath(Grid1, 8, 0, 0, 0);
                Assert.That(result, Is.EqualTo(expectedResult));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [Test]
        public void TestStar2()
        {
            try
            {
                List<Point> expectedResult = new List<Point>() { new Point(0, 0), new Point(1, 1), new Point(2, 2), new Point(3, 3), new Point(4, 4)};
                var result = FindPath(Grid2, 0, 0, 4, 4);
                Assert.That(result, Is.EqualTo(expectedResult));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [Test]
        public void TestStar3()
        {
            try
            {
                List<Point> expectedResult = new List<Point>() { new Point(8, 0), new Point(8, 1), new Point(7, 2), new Point(7, 3), new Point(7, 4),
                new Point(6, 5), new Point(5, 5), new Point(4, 6), new Point(5, 7), new Point(4, 8), new Point(3, 9), new Point(2, 9), new Point(1, 9), new Point(0, 9)};
                var result = FindPath(Grid3, 8, 0, 0, 9);
                Assert.That(result, Is.EqualTo(expectedResult));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [Test]
        public void TestStar4()
        {
            try
            {
                var result = FindPath(BlokedGrid, 4, 0, 0, 0);

            }
            catch (Exception ex)
            {
                Assert.That(ex.Message == "Failed to find the Destination Cell");
                Console.WriteLine(ex.Message);
            }
        }
    }
}