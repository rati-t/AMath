using AMath.Calculus.Matrices.Implementation;
using AMath.Calculus.Vectors.implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMath.Calculus.Geometry.Implementation
{
    public class Plane : ThreeDimesnionalShape
    {
        public Plane(Vector vector, float distanceFromOrigin) : base(null)
        {
            Vector = vector;
            DistanceFromOrigin = distanceFromOrigin;
        }

        public readonly Vector Vector;
        public readonly float DistanceFromOrigin;
        public override float GetSurfaceArea()
        {
            throw new Exception("Plane Does not have surface area");
        }

        public override float GetVolume()
        {
            throw new Exception("Plane Does not have volume");
        }
    }
}
