using AMath.Calculus.Vectors.implementation;
using System.Linq.Expressions;


namespace AMath.Calculus.Tests.Vectors
{
    public class VectorMultiplyTest
    {
        public Vector FirstVector2DWithOrigin { get; set; }
        public Vector SecondVector2DWithOrigin { get; set; }
        public Vector FirstVector2D { get; set; }
        public Vector SecondVector2D { get; set; }
        public Vector FirstVector3DWithOrigin { get; set; }
        public Vector SecondVector3DWithOrigin { get; set; }
        public Vector FirstVector3D { get; set; }
        public Vector SecondVector3D{ get; set; }

        [SetUp]
        public void Setup()
        {
            FirstVector2DWithOrigin = new Vector(5, 4, 8, 11);
            SecondVector2DWithOrigin = new Vector(3, 6, 9, 12);
            FirstVector2D = new Vector(3, 4);
            SecondVector2D = new Vector(5, 6);
            FirstVector3DWithOrigin = new Vector(1, 2, 3, 4, 5, 6);
            SecondVector3DWithOrigin = new Vector(3, 2, 1, 6, 5, 4);
            FirstVector3D = new Vector(4, 2, 5);
            SecondVector3D = new Vector(7, 3, 1);
        }

        [Test]
        public void ScalarMultiply2D()
        {
            var predictedResult = new Vector(12, 16);
            var newVector = FirstVector2D * 4;

            Assert.That(predictedResult == newVector);
        }

        [Test]
        public void ScalarMultiply2DWithOrigin()
        {
            var predictedResult = new Vector(5, 4, 11, 18);
            var newVector = FirstVector2DWithOrigin * 2;

            Assert.That(predictedResult == newVector);
        }

        [Test]
        public void ScalarMultiply3D()
        {
            var predictedResult = new Vector(16, 8, 20);
            var newVector = FirstVector3D * 4;

            Assert.That(predictedResult == newVector);
        }

        [Test]
        public void ScalarMultiply3DWithOrigin()
        {
            var predictedResult = new Vector(1, 2, 3, 7, 8, 9);
            var newVector = FirstVector3DWithOrigin * 2;

            Assert.That(predictedResult == newVector);
        }

        [Test]
        public void DotProduct2D()
        {
            var predictedResult = 39;
            var newVector = FirstVector2D.DotProduct(SecondVector2D);

            Assert.That(predictedResult == newVector);
        }

        [Test]
        public void DotProduct2DWithOrigin()
        {
            var predictedResult = 60;
            var newVector = FirstVector2DWithOrigin.DotProduct(SecondVector2DWithOrigin);

            Assert.That(predictedResult == newVector);
        }

        [Test]
        public void DotProduct3D()
        {
            var predictedResult = 39;
            var newVector = FirstVector3D.DotProduct(SecondVector3D);

            Assert.That(predictedResult == newVector);
        }

        [Test]
        public void DotProduct3DWithOrigin()
        {
            var predictedResult = 27;
            var newVector = FirstVector3DWithOrigin.DotProduct(SecondVector3DWithOrigin);

            Assert.That(predictedResult == newVector);
        }

        [Test]
        public void Multiply2D()
        {
            var predictedResult = new Vector(15, 24);
            var newVector = FirstVector2D * SecondVector2D;

            Assert.That(predictedResult == newVector);
        }

        [Test]
        public void Multiply2DWithOrigin()
        {
            var predictedResult = new Vector(5, 4, 23, 46);
            var newVector = FirstVector2DWithOrigin * SecondVector2DWithOrigin;

            Assert.That(predictedResult == newVector);
        }

        [Test]
        public void Multiply3D()
        {
            var predictedResult = new Vector(28, 6, 5);
            var newVector = FirstVector3D * SecondVector3D;

            Assert.That(predictedResult == newVector);
        }

        [Test]
        public void Multiply3DWithOrigin()
        {
            var predictedResult = new Vector(1, 2, 3, 10, 11, 12);
            var newVector = FirstVector3DWithOrigin * SecondVector3DWithOrigin;

            Assert.That(predictedResult == newVector);
        }

        [Test]
        public void CrossProduct3D()
        {
            var predictedResult = new Vector(-13, -31, -2);
            var newVector = FirstVector3D.CrossProduct(SecondVector3D);

            Assert.That(predictedResult == newVector);
        }

        [Test]
        public void CrossProductWithOrigin()
        {
            var predictedResult = new Vector(1, 2, 3, 1, 2, 3);
            var newVector = FirstVector3DWithOrigin.CrossProduct(SecondVector3DWithOrigin);

            Assert.That(predictedResult == newVector);
        }

    }
}
