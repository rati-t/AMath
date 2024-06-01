using AMath.Calculus.Geometry.Implementation;
using AMath.Calculus.Matrices.Implementation;
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
            float[] expected = new float[8] { -2, 3, -2, 2, 3, 2, 3, 3 };
            TwoDimensionalShape shp = new TwoDimensionalShape(new Matrix(new Matrices.MatrixContent<float>(2, 4, shape)));
            shp.Rotate(90);
            Assert.That(IsEqual(shape, expected));
        }

        // 5 0
        // 6 0
        // 6 1
        // 5 1
        [Test]
        public void ReflectTest()
        {
            float[] expected = new float[8] { -3, 4, -3.6f, 4.8f, -2.8f, 5.4f, -2.2f, 4.6f  };
            TwoDimensionalShape shape = new TwoDimensionalShape(new Matrix(new Matrices.MatrixContent<float>(2, 4, new float[8]{5, 0, 6, 0, 6, 1, 5, 1 })));
            shape.Reflect(2, 0);
            Assert.That(IsEqual(shape.GetCoordinateArray(), expected));
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
