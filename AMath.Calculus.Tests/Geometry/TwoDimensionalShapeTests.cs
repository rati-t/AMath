using AMath.Calculus.common.Points.Implementation;
using AMath.Calculus.Geometry;
using AMath.Calculus.Geometry.Implementation;
using AMath.Calculus.Matrices.Implementation;
using AMath.Calculus.Vectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMath.Calculus.Tests.Geometry
{
    public class TwoDimensionalShapeTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void RotationTest()
        {
            float[] shape = new float[8] { 0, 0, 1, 0, 1, 5, 0, 5 };
            float[] expected = new float[8] { 0, 0, 0, -1, 5, -1, 5, 0 };
            TwoDimensionalShape shp = new TwoDimensionalShape(new Matrix(new Matrices.MatrixContent<float>(2, 4, shape)));
            shp.Rotate(90, new TwoDimensionalPoint(0, 0));
            Assert.That(IsEqual(shp.GetCoordinateArray(), expected));
        }

        [Test]
        public void RotationTestWithRotaionalPointA()
        {
            float[] shape = new float[8] { 0, 0, 1, 0, 1, 5, 0, 5 };
            float[] expected = new float[8] { 0, 2, 0, 1, 5, 1, 5, 2 };
            TwoDimensionalShape shp = new TwoDimensionalShape(new Matrix(new Matrices.MatrixContent<float>(2, 4, shape)));
            shp.Rotate(90, new TwoDimensionalPoint(1, 1));
            Assert.That(IsEqual(shp.GetCoordinateArray(), expected));
        }

        [Test]
        public void RotationTestWithRotaionalPointB()
        {
            float[] shape = new float[8] { 5, 6, 10, 12, 18, 21, 35, 501 };
            float[] expected = new float[8] { 7.3848f, 1.4846f, 15.1829f, 1.9198f, 27.221f, 2.207f, 389.8648f, 317.1331f };
            TwoDimensionalShape shp = new TwoDimensionalShape(new Matrix(new Matrices.MatrixContent<float>(2, 4, shape)));
            shp.Rotate(47, new TwoDimensionalPoint(1, 1));
            Assert.That(IsEqual(shp.GetCoordinateArray(), expected, new Func<float, float>(x => (float)Math.Round((double)x, 4))));
        }

        [Test]
        public void ReflectTest()
        {
            float[] expected = new float[8] { -3, 4, -3.6f, 4.8f, -2.8f, 5.4f, -2.2f, 4.6f };
            TwoDimensionalShape shape = new TwoDimensionalShape(new Matrix(new Matrices.MatrixContent<float>(2, 4, new float[8] { 5, 0, 6, 0, 6, 1, 5, 1 })));
            shape.Reflect(2, 0);
            Assert.That(IsEqual(shape.GetCoordinateArray(), expected));
        }

        [Test]
        public void ScalingTest()
        {
            float[] shape = new float[8] { 0, 0, 1, 0, 1, 5, 0, 5 };
            float[] expected = new float[8] { 0, 0, 2, 0, 2, 10, 0, 10 };
            TwoDimensionalShape shp = new TwoDimensionalShape(new Matrix(new Matrices.MatrixContent<float>(2, 4, shape)));
            shp.Scale(new TwoDimensionalPoint(2, 2), new TwoDimensionalPoint(0, 0));
            Assert.That(IsEqual(shp.GetCoordinateArray(), expected));
        }

        [Test]
        public void ScalingTestB()
        {
            float[] shape = new float[8] { 0, 0, 1, 0, 1, 5, 0, 5 };
            float[] expected = new float[8] { -1, -1, 1, -1, 1, 9, -1, 9 };
            TwoDimensionalShape shp = new TwoDimensionalShape(new Matrix(new Matrices.MatrixContent<float>(2, 4, shape)));
            shp.Scale(new TwoDimensionalPoint(2, 2), new TwoDimensionalPoint(1, 1));
            Assert.That(IsEqual(shp.GetCoordinateArray(), expected));
        }

        [Test]
        public void Perimeter()
        {
            float[] shape = new float[8] { 0, 0, 1, 0, 1, 5, 0, 5 };
            TwoDimensionalShape shp = new TwoDimensionalShape(new Matrix(new Matrices.MatrixContent<float>(2, 4, shape)));
            Assert.That(shp.GetPerimeter() == 12);
        }

        [Test]
        public void PerimeterB()
        {
            float[] shape = new float[8] { 10, 20, 35, 50, 65, 75, 10, 25 };
            TwoDimensionalShape shp = new TwoDimensionalShape(new Matrix(new Matrices.MatrixContent<float>(2, 4, shape)));
            Assert.That(Math.Round(shp.GetPerimeter(), 4) == 157.4328);
        }

        [Test]
        public void SurfaceArea()
        {
            float[] shape = new float[8] { 0, 0, 1, 0, 1, 5, 0, 5 };
            TwoDimensionalShape shp = new TwoDimensionalShape(new Matrix(new Matrices.MatrixContent<float>(2, 4, shape)));
            Assert.That(shp.GetSurfaceArea() == 5);
        }

        [Test]
        public void SurfaceAreaB()
        {
            float[] shape = new float[8] { 10, 10, 20, 30, 40, 70, 80, 5 };
            TwoDimensionalShape shp = new TwoDimensionalShape(new Matrix(new Matrices.MatrixContent<float>(2, 4, shape)));
            Assert.That(shp.GetSurfaceArea() == 2175);
        }

        [Test]
        public void Volume()
        {
            float[] shape = new float[24] { 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 1, 0, 1, 0, 1, 1, 0, 1, 1, 1 };
            ThreeDimesnionalShape shp = new ThreeDimesnionalShape(new Matrix(new Matrices.MatrixContent<float>(3, 8, shape)));
            Assert.That(shp.GetVolume() == 1);
        }

        [Test]
        public void VolumeB()
        {
            float[] shape = new float[15] { 0, 0, 0,
                1, 0, 0,
                1, 0, 1,
                0, 0, 1,
                0.5f, 0.5f, 0.5f };
            ThreeDimesnionalShape shp = new ThreeDimesnionalShape(new Matrix(new Matrices.MatrixContent<float>(3, 5, shape)));
            Assert.That(shp.GetVolume() == 0.17);
        }

        [Test]
        public void IntersectionTest()
        {
            var a = new ShapeIntersectionChecker();

            float[] shapeA = new float[12] { 1, 0, 0, 1, 0, 1, 0, 0, 1, 0.5f, 0.5f, 0.5f };
            ThreeDimesnionalShape shpA = new ThreeDimesnionalShape(new Matrix(new Matrices.MatrixContent<float>(3, 4, shapeA)));

            float[] shapeB = new float[12] { 1, 0, 1, 0, 0, 1, 0.5f, 0.5f, 0.5f, 0, 0, 0 };
            ThreeDimesnionalShape shpB = new ThreeDimesnionalShape(new Matrix(new Matrices.MatrixContent<float>(3, 4, shapeB)));

            Assert.That(a.DoCollide(shpA, shpB) == true);
        }

        [Test]
        public void IntersectionTestB()
        {
            var a = new ShapeIntersectionChecker();

            float[] shapeA = new float[12] { 1, 0, 0, 1, 0, 1, 0, 0, 1, 0.5f, 0.5f, 0.5f };
            ThreeDimesnionalShape shpA = new ThreeDimesnionalShape(new Matrix(new Matrices.MatrixContent<float>(3, 4, shapeA)));

            float[] shapeB = new float[12] { 0, 0, 1, 0, 0, 0, 1, 0, 0, 0.5f, 0.5f, 0.5f };
            ThreeDimesnionalShape shpB = new ThreeDimesnionalShape(new Matrix(new Matrices.MatrixContent<float>(3, 4, shapeB)));

            Assert.That(a.DoCollide(shpA, shpB) == false);
        }

        private bool IsEqual(float[] a, float[] b, Func<float, float> aggregate = null)
        {
            if (a.Length != b.Length)
                return false;

            for (int i = 0; i < a.Length; i++)
            {
                if (aggregate == null ? a[i] != b[i] : aggregate(a[i]) != aggregate(b[i]))
                    return false;
            }

            return true;
        }
    }
}
