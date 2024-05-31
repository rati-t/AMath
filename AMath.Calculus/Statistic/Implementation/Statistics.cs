using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMath.Calculus.Statistic.Implementation
{
    public class Statistics : BaseStatistics<decimal>
    {
        internal override decimal Add(decimal a, decimal b)
            => a + b;

        internal override decimal Average(decimal[] main)
            => main.Average();

        internal override decimal Divide(decimal a, int b)
            => a / b;
        
        internal override decimal Divide(decimal a, decimal b)
            => a / b;

        internal override decimal Multiply(decimal a, decimal b)
            => a * b;

        internal override decimal SquareRoot(decimal a)
            => (decimal)Math.Sqrt((double)a);

        internal override decimal Subtruct(decimal a, decimal b)
            => a - b;

        internal override decimal Sum(decimal[] main)
            => main.Sum();

        internal override decimal SumSquare(decimal[] main)
            => main.Sum(item => item * item);
    }
}
