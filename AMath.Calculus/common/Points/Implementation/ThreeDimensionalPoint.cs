using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMath.Calculus.common.Points.Implementation
{
    public class ThreeDimensionalPoint : Point<float>
    {
        internal float ZCoordinate { get; set; }
        public ThreeDimensionalPoint(float xCoordinate, float yCoordinate, float zCoordinate) : base(xCoordinate, yCoordinate)
        {
            _builder = new PointBuilder();
            ZCoordinate = zCoordinate;
        }

        public override Point<float> Add(Point<float> other)
        {
            if (other is ThreeDimensionalPoint other3D)
            {
                return new ThreeDimensionalPoint(
                    XCoordinate + other3D.XCoordinate,
                    YCoordinate + other3D.YCoordinate,
                    ZCoordinate + other3D.ZCoordinate
                );
            }
            throw new ArgumentException("The point to add must be of type ThreeDimensionalPoint.");
        }

        public override Point<float> Subtract(Point<float> other)
        {
            if (other is ThreeDimensionalPoint other3D)
            {
                return new ThreeDimensionalPoint(
                    XCoordinate - other3D.XCoordinate,
                    YCoordinate - other3D.YCoordinate,
                    ZCoordinate - other3D.ZCoordinate
                );
            }
            throw new ArgumentException("The point to subtract must be of type ThreeDimensionalPoint.");
        }

        public override bool Equals(object? obj)
        {
            if (obj != null && obj is ThreeDimensionalPoint other)
            {
                return XCoordinate.Equals(other.XCoordinate) && YCoordinate.Equals(other.YCoordinate) && ZCoordinate.Equals(other.ZCoordinate);
            }
            return false;
        }

        public override Point<float> MultiplyByNumber(float other)
        {
            return new ThreeDimensionalPoint(XCoordinate * other, YCoordinate * other, ZCoordinate * other);
        }

        public override float DotProduct(Point<float> other)
        {
            if (other is ThreeDimensionalPoint other3D)
            {
                return (XCoordinate * other3D.XCoordinate) + (YCoordinate * other3D.YCoordinate) + (ZCoordinate * other3D.ZCoordinate);
            }
            throw new ArgumentException("The point to DotProduct must be of type ThreeDimensionalPoint.");
        }

        public override Point<float> Multiply(Point<float> other)
        {
            if (other is ThreeDimensionalPoint other3D)
            {
                return new ThreeDimensionalPoint(XCoordinate * other3D.XCoordinate, YCoordinate * other3D.YCoordinate, ZCoordinate * other3D.ZCoordinate);
            }
            throw new ArgumentException("The point to multiply must be of type ThreeDimensionalPoint.");
        }

        public Point<float> CrossProduct(ThreeDimensionalPoint other)
        {
            return new ThreeDimensionalPoint(
                (YCoordinate * other.ZCoordinate) - (ZCoordinate * other.YCoordinate),
                (XCoordinate * other.ZCoordinate) - (ZCoordinate * other.XCoordinate),
                (XCoordinate * other.YCoordinate) - (YCoordinate * other.XCoordinate)
                );
        }

        public override Point<float> DevideByNumber(float other)
        {
            return new ThreeDimensionalPoint(XCoordinate / other, YCoordinate / other, ZCoordinate / other);
        }

        public override Point<float> Devide(Point<float> other)
        {
            if (other is ThreeDimensionalPoint other3D)
            {
                return new ThreeDimensionalPoint(XCoordinate / other3D.XCoordinate, YCoordinate / other3D.YCoordinate, ZCoordinate / other3D.ZCoordinate);
            }
            throw new ArgumentException("The point to devide must be of type ThreeDimensionalPoint.");
        }

        public override float NormilizeValue()
        {
            return (float)Math.Sqrt(XCoordinate * XCoordinate + YCoordinate * YCoordinate + ZCoordinate * ZCoordinate);
        }

        public override bool IsOrigin()
        {
            return XCoordinate == 0 && YCoordinate == 0 && ZCoordinate == 0;
        }

        public override float[] GetCoordinates()
        {
            return new float[3] { XCoordinate, YCoordinate, ZCoordinate };
        }

        public override string ToString()
        {
            return $"Vector(X: {XCoordinate}, Y: {YCoordinate}, Z: {ZCoordinate})";
        }
    }
}
