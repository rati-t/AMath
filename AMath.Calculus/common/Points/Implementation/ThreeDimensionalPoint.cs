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
            throw new ArgumentException("The point to add must be of type ThreeDimensionalPoint.");
        }

        public override bool Equals(object? obj)
        {
            if (obj != null && obj is ThreeDimensionalPoint other)
            {
                return XCoordinate.Equals(other.XCoordinate) && YCoordinate.Equals(other.YCoordinate) && ZCoordinate.Equals(other.ZCoordinate);
            }
            return false;
        }

        public override bool IsOrigin()
        {
            return XCoordinate == 0 && YCoordinate == 0 && ZCoordinate == 0;
        }

        public override float[] GetCoordinates()
        {
            return new float[3] { XCoordinate, YCoordinate, ZCoordinate };
        }
    }
}
