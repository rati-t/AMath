using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMath.Calculus.common.Points.Implementation
{
    internal class TwoDimensionalPoint : Point<float>
    {
        public TwoDimensionalPoint(float xCoordinate, float yCoordinate) : base(xCoordinate, yCoordinate)
        {
            _builder = new PointBuilder();
        }

        public override Point<float> Add(Point<float> other)
        {
            return new TwoDimensionalPoint(XCoordinate + other.XCoordinate, YCoordinate + other.YCoordinate);
        }

        public override Point<float> Subtract(Point<float> other)
        {
            return new TwoDimensionalPoint(XCoordinate - other.XCoordinate, YCoordinate - other.YCoordinate);
        }

        public override bool Equals(object? obj)
        {
            if (obj != null && obj is TwoDimensionalPoint other)
            {
                return XCoordinate.Equals(other.XCoordinate) && YCoordinate.Equals(other.YCoordinate);
            }
            return false;
        }

        public override Point<float> MultiplyByNumber(float other)
        {
            return new TwoDimensionalPoint(XCoordinate * other, YCoordinate * other);
        }

        public override float DotProduct(Point<float> other)
        {
            return (XCoordinate * other.XCoordinate) + (YCoordinate * other.YCoordinate);
        }

        public override Point<float> Multiply(Point<float> other)
        {
            return new TwoDimensionalPoint(XCoordinate * other.XCoordinate, YCoordinate * other.YCoordinate);
        }

        public override Point<float> DevideByNumber(float other)
        {
            return new TwoDimensionalPoint(XCoordinate / other, YCoordinate / other);
        }

        public override Point<float> Devide(Point<float> other)
        {
            return new TwoDimensionalPoint(XCoordinate / other.XCoordinate, YCoordinate / other.YCoordinate);
        }

        public override float NormilizeValue()
        {
            return (float)Math.Sqrt(XCoordinate * XCoordinate + YCoordinate * YCoordinate);
        }
    }
}
