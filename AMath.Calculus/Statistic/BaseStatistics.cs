using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMath.Calculus.Statistic
{
    public abstract class BaseStatistics<T> where T : struct
    {
        public T Corellation(T[] main, T[] other)
        {
            if (IsInvalidArray(main) || IsInvalidArray(other))
                return default(T);

            if (main.Length != other.Length)
                return default(T);

            T mainAvg = Average(main);
            T otherAvg = Average(other);

            T dividend = default(T);
            T divisorMainSum = default(T);
            T divisorOtherSum = default(T);

            for (int i = 0; i < main.Length; i++)
            {
                dividend = Add(dividend, Multiply(Subtruct(main[i], mainAvg), Subtruct(other[i], otherAvg)));
                divisorMainSum = Add(divisorMainSum, Multiply(Subtruct(main[i], mainAvg), Subtruct(main[i], mainAvg)));
                divisorOtherSum = Add(divisorOtherSum, Multiply(Subtruct(other[i], otherAvg), Subtruct(other[i], otherAvg)));
            }

            return Divide(dividend, SquareRoot(Multiply(divisorMainSum, divisorOtherSum)));
        }

        public T Covariance(T[] main, T[] other, CovarianceType covarianceType)
        {
            if (IsInvalidArray(main) || IsInvalidArray(other))
                return default(T);

            if(main.Length != other.Length) 
                return default(T);

            T mainAvg = Average(main);
            T otherAvg = Average(other);

            T sum = default(T);
            for (int i = 0; i < main.Length; i++)
            {
                sum = Add(sum, Multiply(Subtruct(main[i], mainAvg), Subtruct(other[i], otherAvg)));
            }

            return Divide(sum, covarianceType == CovarianceType.Population ? main.Length : main.Length - 1);
        }

        public T StandardDeviation(T[] main)
        {
            if (IsInvalidArray(main))
                return default(T);

            T avg = Average(main);
            int size = main.Length;

            T sum = default(T);
            for (int i = 0; i < size; i++)
            {
                T ans = Subtruct(main[i], avg);
                sum = Add(sum, Multiply(ans, ans));
            }

            return SquareRoot(Divide(sum, size));
        }

        public T Variance(T[] main)
        {
            if (IsInvalidArray(main))
                return default(T);

            T avg = Average(main);
            int size = main.Length;

            T sum = default(T);
            for (int i = 0; i < size; i++)
            {
                T ans = Subtruct(main[i], avg);
                sum = Add(sum, Multiply(ans, ans));
            }

            return Divide(sum, size - 1);
        }

        internal abstract T Average(T[] main);
        internal abstract T Sum(T[] main);
        internal abstract T SumSquare(T[] main);
        internal abstract T Subtruct(T a, T b);
        internal abstract T Multiply(T a, T b);
        internal abstract T Add(T a, T b);
        internal abstract T Divide(T a, int b);
        internal abstract T Divide(T a, T b);
        internal abstract T SquareRoot(T a);
        private bool IsInvalidArray(T[] main)
        {
            return main == null || main.Length == 0;
        }
    }

    public enum CovarianceType
    {
        Sample,
        Population
    }
}
