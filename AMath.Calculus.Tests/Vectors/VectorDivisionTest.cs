using AMath.Calculus.Vectors.implementation;
using System.Linq.Expressions;


namespace AMath.Calculus.Tests.Vectors
{
    public class VectorDivisionTest
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
        public void ScalarDevide2D()
        {
            var predictedResult = new Vector(3.0f / 4, 1);
            var newVector = FirstVector2D / 4;

            Assert.That(predictedResult == newVector);
        }

        [Test]
        public void ScalarDevide2DWithOrigin()
        {
            var predictedResult = new Vector(5, 4, 5 + 3.0f / 4, 4 + 7.0f / 4);
            var newVector = FirstVector2DWithOrigin / 4;

            Assert.That(predictedResult == newVector);
        }

        [Test]
        public void ScalarDevide3D()
        {
            var predictedResult = new Vector(1, 0.5f, 5.0f / 4);
            var newVector = FirstVector3D / 4;

            Assert.That(predictedResult == newVector);
        }

        [Test]
        public void ScalarDevide3DWithOrigin()
        {
            var predictedResult = new Vector(1, 2, 3, 1 + 3.0f / 4, 2 + 3.0f / 4, 3 + 3.0f / 4);
            var newVector = FirstVector3DWithOrigin / 4;

            Assert.That(predictedResult == newVector);
        }

        [Test]
        public void Devide2D()
        {
            var predictedResult = new Vector(3.0f / 5, 4.0f / 6);
            var newVector = FirstVector2D / SecondVector2D;

            Assert.That(predictedResult == newVector);
        }

        [Test]
        public void Devide2DWithOrigin()
        {
            var predictedResult = new Vector(5, 4, 5.5f, 4 + 7.0f / 6);
            var newVector = FirstVector2DWithOrigin / SecondVector2DWithOrigin;

            Assert.That(predictedResult == newVector);
        }

        [Test]
        public void Devide3D()
        {
            var predictedResult = new Vector(4.0f / 7, 2.0f / 3, 5);
            var newVector = FirstVector3D / SecondVector3D;

            Assert.That(predictedResult == newVector);
        }

        [Test]
        public void Devide3DWithOrigin()
        {
            var predictedResult = new Vector(1, 2, 3, 2, 3, 4);
            var newVector = FirstVector3DWithOrigin / SecondVector3DWithOrigin;

            Assert.That(predictedResult == newVector);
        }

        [Test]
        public void Normilize2D()
        {
            var predictedResult = new Vector(0.6f, 0.8f);
            var newVector = FirstVector2D.NormilizeVector();

            Assert.That(predictedResult == newVector);
        }

        [Test]
        public void Normilize2DWithOrigin()
        {
            var predictedResult = new Vector(3.0f / (float)Math.Sqrt(58), 7.0f / (float)Math.Sqrt(58));
            var newVector = FirstVector2DWithOrigin.NormilizeVector();

            Assert.That(predictedResult == newVector);
        }

        [Test]
        public void Normilize3D()
        {
            var predictedResult = new Vector(4.0f / (float)Math.Sqrt(45), 2.0f / (float)Math.Sqrt(45), 5.0f / (float)Math.Sqrt(45));
            var newVector = FirstVector3D.NormilizeVector();

            Assert.That(predictedResult == newVector);
        }

        [Test]
        public void Normilize3DWithOrigin()
        {
            var predictedResult = new Vector(3.0f / (float)Math.Sqrt(27), 3.0f / (float)Math.Sqrt(27), 3.0f / (float)Math.Sqrt(27));
            var newVector = FirstVector3DWithOrigin.NormilizeVector();

            Assert.That(predictedResult == newVector);
        }



    }
}
