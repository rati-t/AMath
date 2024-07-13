using AMath.Calculus.Vectors.implementation;
using System.Linq.Expressions;


namespace AMath.Calculus.Tests.Vectors
{
    public class VectorProjectionTest
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
            FirstVector2DWithOrigin = new Vector(1, 1, 5, 5);
            SecondVector2DWithOrigin = new Vector(2, 2, 4, 4);
            FirstVector2D = new Vector(3, 4);
            SecondVector2D = new Vector(1, 2);
            FirstVector3DWithOrigin = new Vector(1, 2, 3, 4, 5, 6);
            SecondVector3DWithOrigin = new Vector(3, 2, 1, 6, 5, 4);
            FirstVector3D = new Vector(1, 2, 3);
            SecondVector3D = new Vector(3, 2, 1);
        }

        [Test]
        public void Projection2D()
        {
            var predictedResult = new Vector(2.2f, 4.4f);
            var newVector = FirstVector2D.Projection(SecondVector2D);

            Assert.That(predictedResult == newVector);
        }

        [Test]
        public void Projection2DWithOrigin()
        {
            var predictedResult = new Vector(1, 1, 5, 5);
            var newVector = FirstVector2DWithOrigin.Projection(SecondVector2DWithOrigin);

            Assert.That(predictedResult == newVector);
        }

        [Test]
        public void Projection3D()
        {
            var predictedResult = new Vector(15.0f / 7, 10.0f / 7, 5.0f / 7);
            var newVector = FirstVector3D.Projection(SecondVector3D);

            Assert.That(predictedResult == newVector);
        }

        [Test]
        public void Projection3DWithOrigin()
        {
            var predictedResult = new Vector(1, 2, 3, 4, 5, 6);
            var newVector = FirstVector3DWithOrigin.Projection(SecondVector3DWithOrigin);

            Assert.That(predictedResult == newVector);
        }


    }
}
