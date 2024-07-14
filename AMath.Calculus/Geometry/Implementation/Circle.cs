using AMath.Calculus.common;
using AMath.Calculus.common.Points.Implementation;
using AMath.Calculus.Matrices.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMath.Calculus.Geometry.Implementation
{
    public class Circle : TwoDimensionalShape
    {
        public Circle(float radius, TwoDimensionalPoint center) : base(null)
        {
            Radius = radius;
            Center = center;
        }
        public virtual float GetPerimeter()
        {
            return (float)Math.PI * 2 * Radius;
        }

        public override float GetSurfaceArea()
        {
            return (float)(Math.PI * Math.Pow(Radius, 2));
        }
        public float Radius { get; set; }
        public TwoDimensionalPoint Center { get; set; }
    }
}
