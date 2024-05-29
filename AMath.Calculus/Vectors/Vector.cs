using AMath.Calculus.common.Points;
using System.Numerics;


namespace AMath.Calculus.Vectors
{
    public class Vector : BaseVector<float>
    {
        internal Point<float> StartPoint { get; set; }
        internal Point<float> EndPoint { get; set; }
        
        public Vector(float startX, float startY, float endX, float endY) 
        {  
            StartPoint = new TwoDimensionalPoint<float>(startX, startY); 
            EndPoint = new TwoDimensionalPoint<float>(endX, endY); 
        }

        internal Vector(Point<float> startPoint, Point<float> endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }

        public static Vector operator + (Vector first, Vector second)
        {
            return null;
        }
    }
}
