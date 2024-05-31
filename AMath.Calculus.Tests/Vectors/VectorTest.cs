using AMath.Calculus.Vectors;
using System.Linq.Expressions;


namespace AMath.Calculus.Tests.Vectors
{
    public class VectorTest
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
        public void Add2D()
        {
            var predictedResult = new Vector(8, 10);
            var newVector = FirstVector2D + SecondVector2D;

            Assert.That(predictedResult == newVector);
        }

        [Test]
        public void Subtarct2D()
        {
            var predictedResult = new Vector(-2, -2);
            var newVector = FirstVector2D - SecondVector2D;

            Assert.That(predictedResult == newVector);
        }

        [Test]
        public void Add2DWithOrigin()
        {
            var predictedResult = new Vector(5, 4, 14, 17);
            var newVector = FirstVector2DWithOrigin + SecondVector2DWithOrigin;

            Assert.That(predictedResult == newVector);
        }

        [Test]
        public void Subtarct2DOrigin()
        {
            var predictedResult = new Vector(5, 4, 2, 5);
            var newVector = FirstVector2DWithOrigin - SecondVector2DWithOrigin;

            Assert.That(predictedResult == newVector);
        }

        [Test]
        public void Add3D()
        {
            var predictedResult = new Vector(11, 5, 6);
            var newVector = FirstVector3D + SecondVector3D;

            Assert.That(predictedResult == newVector);
        }

        [Test]
        public void Subtarct3D()
        {
            var predictedResult = new Vector(-3, -1, 4);
            var newVector = FirstVector3D - SecondVector3D;

            Assert.That(predictedResult == newVector);
        }

        [Test]
        public void Add3DWithOrigin()
        {
            var predictedResult = new Vector(1, 2, 3, 7, 8, 9);
            var newVector = FirstVector3DWithOrigin + SecondVector3DWithOrigin;

            Assert.That(predictedResult == newVector);
        }

        [Test]
        public void Subtarct3DOrigin()
        {
            var predictedResult = new Vector(1, 2, 3, 1, 2, 3);
            var newVector = FirstVector3DWithOrigin - SecondVector3DWithOrigin;

            Assert.That(predictedResult == newVector);
        }
    }
}
