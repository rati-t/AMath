using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMath.Calculus.common.Points
{
    internal class TwoDimensionalPoint : Point<float>
    {
        public TwoDimensionalPoint(float xCoordinate, float yCoordinate) : base(xCoordinate, yCoordinate)
        { 
        }

        public override Point<float> Add(Point<float> other)
        {
            return new TwoDimensionalPoint(XCoordinate + other.XCoordinate, YCoordinate + other.YCoordinate);
        }

        public override Point<float> Subtract(Point<float> other)
        {
            throw new NotImplementedException();
        }
    }
}
