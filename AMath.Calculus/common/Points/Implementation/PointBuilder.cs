using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMath.Calculus.common.Points.Implementation
{
    public class PointBuilder : BasePointBuilder<float>
    {
        public override Point<float> Create(ThreeDimensionalPoint other)
        {
            return new ThreeDimensionalPoint(other.XCoordinate, other.YCoordinate, other.ZCoordinate);
        }

        public override Point<float> Create(TwoDimensionalPoint other)
        {
            return new TwoDimensionalPoint(other.XCoordinate, other.YCoordinate);
        }
    }
}
