using AMath.Calculus.Vectors;


namespace AMath.Calculus.Tests.Vector
{
    public class VectorTest
    {
        public Vector<int> Vector { get; set; }

        [SetUp]
        public void Setup()
        {
            Vector = new Vector<int>(3, 4, 5, 6);
        }

        [Test]
        public void Get()
        {
            var vector = new Vector<int>(3, 4, 5, 6);
            var a = Vector + vector;
            Assert.That(a == null);
        }
    }
}
