using AMath.Calculus.common.Points;
using System.Numerics;


namespace AMath.Calculus.Vectors
{
    public class Vector : BaseVector<float>
    {
        internal Point<float> StartPoint { get; set; }
        internal Point<float> EndPoint { get; set; }
        internal Point<float> ActualPoint { get; set; }

        public Vector(float startX, float startY, float endX, float endY) 
        {  
            StartPoint = new TwoDimensionalPoint(startX, startY); 
            EndPoint = new TwoDimensionalPoint(endX, endY);
            ActualPoint = StartPoint - EndPoint;
        }

        internal Vector(Point<float> startPoint, Point<float> endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            ActualPoint = StartPoint - EndPoint;
        }

        public Vector(float xCoordinate, float yCoordinate)
        {
            StartPoint = new TwoDimensionalPoint(0, 0);
            EndPoint = new TwoDimensionalPoint(xCoordinate, yCoordinate);
            ActualPoint = StartPoint - EndPoint;
        }

        public static Vector operator + (Vector first, Vector second)
        {
            return null;
        }
    }
}
