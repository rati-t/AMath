using AMath.Calculus.Vectors;


namespace AMath.Calculus.Tests.Vectors
{
    public class VectorTest
    {
        public Vector FirstVector { get; set; }
        public Vector SecondVector { get; set; }

        [SetUp]
        public void Setup()
        {
            FirstVector = new Vector(5, 4, 8, 11);
            SecondVector = new Vector(3, 6, 9, 12);
        }

        [Test]
        public void Add()
        {
            var predictedResult = FirstVector.Add(SecondVector);
            var newVector = FirstVector + SecondVector;

            Assert.That(Fir == null);
        }

        [Test]
        public void Subtarct()
        {
            Assert.That(a == null);
        }
    }
}
