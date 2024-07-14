using AMath.Calculus.common.Points.Implementation;
using AMath.Calculus.Matrices.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMath.Calculus.Geometry.Implementation
{
    public class Sphere : ThreeDimesnionalShape
    {
        public Sphere(float radius, ThreeDimensionalPoint center) : base(null)
        {
            Radius = radius;
            Center = center;
        }

        public override float GetSurfaceArea()
        {
            return (float)(4 * Math.PI * Math.Pow(Radius, 2));
        }

        public override float GetVolume()
        {
            return (float)((4.0 / 3.0) * Math.PI * Math.Pow(Radius, 3));
        }

        public float Radius { get; set; }
        public ThreeDimensionalPoint Center { get; set; }
    }
}
