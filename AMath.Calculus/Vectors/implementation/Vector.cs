using AMath.Calculus.common.Points;
using AMath.Calculus.common.Points.Implementation;
using System.Numerics;


namespace AMath.Calculus.Vectors.implementation
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
        internal Vector(Point<float> endPoint)
        {
            StartPoint = endPoint is ThreeDimensionalPoint ? new ThreeDimensionalPoint(0, 0, 0) : new TwoDimensionalPoint(0, 0);
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

        public override BaseVector<float> Add(BaseVector<float> other)
        {
            return new Vector(StartPoint, StartPoint + (ActualPoint + other.ActualPoint));
        }

        public override BaseVector<float> Subtract(BaseVector<float> other)
        {
            return new Vector(StartPoint, StartPoint + (ActualPoint - other.ActualPoint));
        }

        public override BaseVector<float> ScalarMultiply(float other)
        {
            return new Vector(StartPoint, StartPoint + (ActualPoint * other));
        }

        public override float DotProduct(BaseVector<float> other)
        {
            return ActualPoint.DotProduct(other.ActualPoint);
        }

        public override BaseVector<float> Multiply(BaseVector<float> other)
        {
            return new Vector(StartPoint, StartPoint + (ActualPoint * other.ActualPoint));
        }

        public override BaseVector<float> CrossProduct(BaseVector<float> other)
        {
            if (ActualPoint is ThreeDimensionalPoint first && other.ActualPoint is ThreeDimensionalPoint second)
            {
                return new Vector(StartPoint, StartPoint + first.CrossProduct(second));
            }
            throw new ArgumentException("The vector to CrossProduct must be ThreeDimensional.");
        }

        public override BaseVector<float> Divide(BaseVector<float> other)
        {
            return new Vector(StartPoint, StartPoint + (ActualPoint / other.ActualPoint));
        }

        public override BaseVector<float> ScalarDivide(float other)
        {
            return new Vector(StartPoint, StartPoint + (ActualPoint / other));
        }

        public override BaseVector<float> NormilizeVector()
        {
            return new Vector(ActualPoint / ActualPoint.NormilizeValue());
        }

        public override BaseVector<float> Projection(BaseVector<float> other)
        {
            return new Vector(StartPoint, StartPoint + (DotProduct(other) / other.DotProduct(other) * other).ActualPoint);
        }

        public override string ToString()
        {
            return $"Vector(StartPoint: {StartPoint}, EndPoint: {EndPoint}, ActualPoint: {ActualPoint})";
        }
    }
}
