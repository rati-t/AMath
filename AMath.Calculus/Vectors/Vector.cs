using AMath.Calculus.common.Points;
using AMath.Calculus.common.Points.Implementation;
using System.Numerics;


namespace AMath.Calculus.Vectors
{
    public class Vector : BaseVector<float>
    {
        public Vector(float startX, float startY, float endX, float endY) 
        {  
            StartPoint = new TwoDimensionalPoint(startX, startY); 
            EndPoint = new TwoDimensionalPoint(endX, endY);
            ActualPoint = EndPoint - StartPoint;
        }

        public Vector(float startX, float startY, float startZ, float endX, float endY, float endZ)
        {
            StartPoint = new ThreeDimensionalPoint(startX, startY, startZ);
            EndPoint = new ThreeDimensionalPoint(endX, endY, endZ);
            ActualPoint = EndPoint - StartPoint;
        }

        internal Vector(Point<float> startPoint, Point<float> endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            ActualPoint = EndPoint - StartPoint;
        }

        public Vector(float xCoordinate, float yCoordinate)
        {
            StartPoint = new TwoDimensionalPoint(0, 0);
            EndPoint = new TwoDimensionalPoint(xCoordinate, yCoordinate);
            ActualPoint = EndPoint - StartPoint;
        }

        public Vector(float xCoordinate, float yCoordinate, float zCoordinate)
        {
            StartPoint = new ThreeDimensionalPoint(0, 0, 0);
            EndPoint = new ThreeDimensionalPoint(xCoordinate, yCoordinate, zCoordinate);
            ActualPoint = EndPoint - StartPoint;
        }

        internal override BaseVector<float> Add(BaseVector<float> other)
        {
            return new Vector(StartPoint, StartPoint + (ActualPoint + other.ActualPoint));
        }

        internal override BaseVector<float> Subtract(BaseVector<float> other)
        {
            return new Vector(StartPoint, StartPoint + (ActualPoint - other.ActualPoint));
        }
    }
}
