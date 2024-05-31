using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMath.Statistics.Statistic;
using AMath.Statistics.Statistic.Implementation;

namespace AMath.Statistics.Tests.StatisticsTests
{
    public partial class StatisticsTests
    {
        public decimal[] TestData_1 { get; set; }
        public decimal[] TestData_2 { get; set; }
        public decimal[] TestData_3 { get; set; }
        public decimal[] TestData_4 { get; set; }

        [SetUp]
        public void Setup()
        {
            TestData_1 = new decimal[5] { 0, 1, 2, 3, 4 };
            TestData_2 = new decimal[5] { 0, 1, 2, 3, 4 };
            TestData_3 = new decimal[6] { 0, 102, 1050, 12314, 124, 102 };
            TestData_4 = new decimal[6] { 0, 1512, 123, 4125, 12, 13 };
        }

        [Test]
        public void PopulationCovariance()
        {
            var covariance = new Stats().Covariance(TestData_1, TestData_2, Statistic.CovarianceType.Population);
            Assert.That(covariance == 2);
        }

        [Test]
        public void SampleCovariance()
        {
            var covariance = new Stats().Covariance(TestData_1, TestData_2, Statistic.CovarianceType.Sample);
            Assert.That(covariance == 2.5m);
        }

        [Test]
        public void PopulationCovarianceAdvanced()
        {
            var covariance = new Stats().Covariance(TestData_3, TestData_4, Statistic.CovarianceType.Population);
            Assert.That((int)covariance == 6313344);
        }

        [Test]
        public void SampleCovarianceAdvanced()
        {
            var covariance = new Stats().Covariance(TestData_3, TestData_4, Statistic.CovarianceType.Sample);
            Assert.That((int)covariance == 7576013);
        }

        [Test]
        public void StandartDeviation()
        {
            var expected = 1.4142135623731m;
            var result = new Stats().StandardDeviation(TestData_1);
            Assert.That(Math.Round(expected, 3) == Math.Round(result, 3));
        }

        [Test]
        public void StandartDeviationAdvanced()
        {
            var expected = 4500.5210068761m;
            var result = new Stats().StandardDeviation(TestData_3);
            Assert.That(Math.Round(expected, 3) == Math.Round(result, 3));
        }


        [Test]
        public void Corellation()
        {
            var expected = 1;
            var result = new Stats().Corellation(TestData_1, TestData_2);
            Assert.That(result == expected);
        }

        [Test]
        public void CorellationAdvanced()
        {
            var expected = 0.927m;
            var result = new Stats().Corellation(TestData_3, TestData_4);
            Assert.That(Math.Round(result,3) == (Math.Round(expected,3)));
        }

        [Test]
        public void Variance()
        {
            var expected = 2.5m;
            var result = new Stats().Variance(TestData_1);
            Assert.That(result == expected);
        }
        [Test]
        public void VarianceAdvanced()
        {
            var expected = 24305627m;
            var result = new Stats().Variance(TestData_3);
            Assert.That(Math.Round(result,0) == Math.Round(expected,0));
        }

    }
}
