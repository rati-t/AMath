using System.Linq.Expressions;
using AMath.Calculus.common.FunctionalMath;


namespace AMath.Calculus.Tests.FunctionalMathTest
{
    public class FunctionalMathTest
    {

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ComputeDerivative1()
        {
            float predictedResult = 4.00f;
            Func<float, float> testFunc = (float x) => x * x;
            float result = FunctionalMath.CalculateDerivative(testFunc, 2);
            Assert.That(predictedResult == Math.Round(result, 2));
        }

        [Test]
        public void ComputeDerivative2()
        {
            float predictedResult = 60.00f;
            Func<float, float> testFunc = (float x) => x * x * x * 4 + x * x * 3 + 40;
            float result = FunctionalMath.CalculateDerivative(testFunc, 2);
            Assert.That(predictedResult == Math.Round(result, 2));
        }

        [Test]
        public void ComputeIntegral1()
        {
            float predictedResult = 8.00f;
            Func<float, float> testFunc = (float x) => x * x * 3;
            float result = FunctionalMath.CalculateIntegral(testFunc, 0, 2, 100);
            Assert.That(predictedResult == Math.Round(result, 2));
        }

        [Test]
        public void ComputeIntegral2()
        {
            float predictedResult = 104.00f;
            Func<float, float> testFunc = (float x) => x * x * x * 4 + x * x * 3 + 40;
            float result = FunctionalMath.CalculateIntegral(testFunc, 0, 2, 100);
            Assert.That(predictedResult == Math.Round(result, 2));
        }

        [Test]
        public void ComputeEquation1()
        {
            float predictedResult = 0.72f;
            Func<float, float> testFunc = (float x) => 3 * x * x * x + 4 * x - 4;
            float result = FunctionalMath.CalculateEquation(testFunc, 0, 1);
            Assert.That(predictedResult == (float)Math.Round(result, 2));
        }

        [Test]
        public void ComputeEquation2()
        {
            float predictedResult = 104.00f;
            Func<float, float> testFunc = (float x) => x * x * x * 4 + x * x * 3 + 40;
            float result = FunctionalMath.CalculateIntegral(testFunc, 0, 2, 100);
            Assert.That(predictedResult == Math.Round(result, 2));
        }
    }
}
