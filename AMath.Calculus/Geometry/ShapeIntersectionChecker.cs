using AMath.Calculus.common.Points.Implementation;
using AMath.Calculus.Geometry.Implementation;
using AMath.Calculus.Matrices;
using AMath.Calculus.Vectors.implementation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using AMath.Calculus.Geometry.Implementation;
using System.Threading.Tasks;

namespace AMath.Calculus.Geometry
{
    public class ShapeIntersectionChecker
    {
        // Not Done Yet
        public bool DoCollide(ThreeDimesnionalShape a, ThreeDimesnionalShape b)
        {
            List<Vector> simplex = new List<Vector>()
            {
                new Vector(0, 0, 0),
                new Vector(0, 0, 0),
                new Vector(0, 0, 0),
                new Vector(0, 0, 0)
            }; // Maximum simplex size for 3D space

            Vector Support(ThreeDimesnionalShape shape, Vector direction)
            {
                Vector farthestPoint = simplex[0];
                float maxDot = farthestPoint.DotProduct(direction);

                var points = (List<ThreeDimensionalPoint>)shape.GetPoints(shape.Matrix);
                for (int i = 1; i < points.Count(); i++)
                {
                    var vector = new Vector(points[i].XCoordinate, points[i].YCoordinate, points[i].ZCoordinate);
                    float dotProduct = vector.DotProduct(direction);
                    if (dotProduct > maxDot)
                    {
                        maxDot = dotProduct;
                        farthestPoint = vector;
                    }
                }

                return farthestPoint;
            }

            bool DoSimplex(ref int simplexSize, ref Vector direction)
            {
                Vector newPoint = (Vector)Support(a, direction).Subtract(Support(b, (Vector)direction.ScalarMultiply(-1)));
                simplex[simplexSize++] = newPoint;

                if (simplexSize == 2)
                {
                    // Line case
                    Vector a = simplex[1];
                    Vector b = simplex[0];
                    Vector ab = (Vector)b.Subtract(a);
                    Vector ao = (Vector)a.ScalarMultiply(-1);
                    direction = (Vector)ab.CrossProduct(ao.CrossProduct(ab));
                }
                else if (simplexSize == 3)
                {
                    // Triangle case
                    Vector a = simplex[2];
                    Vector b = simplex[1];
                    Vector c = simplex[0];
                    Vector ab = (Vector)b.Subtract(a);
                    Vector ac = (Vector)c.Subtract(a);
                    Vector abc = (Vector)ab.CrossProduct(ac);

                    if (abc.CrossProduct(ac).DotProduct(a) > 0)
                    {
                        direction = (Vector)ac.CrossProduct(a);
                        simplex[1] = c;
                    }
                    else if (ab.CrossProduct(abc).DotProduct(a) > 0)
                    {
                        direction = (Vector)ab.CrossProduct(a);
                        simplex[0] = b;
                        simplex[1] = a;
                    }
                    else
                    {
                        return true;
                    }
                }
                else if (simplexSize == 4)
                {
                    // Tetrahedron case
                    Vector a = simplex[3];
                    Vector b = simplex[2];
                    Vector c = simplex[1];
                    Vector d = simplex[0];
                    Vector ab = (Vector)b.Subtract(a);
                    Vector ac = (Vector)c.Subtract(a);
                    Vector ad = (Vector)d.Subtract(a);
                    Vector abc = (Vector)(ab.CrossProduct(ac));
                    Vector acd = (Vector)(ac.CrossProduct(ad));
                    Vector adb = (Vector)(ad.CrossProduct(ab));

                    if (abc.DotProduct(a) > 0)
                    {
                        direction = abc;
                        simplex.RemoveAt(0);
                        simplexSize--;
                    }
                    else if (acd.DotProduct(a) > 0)
                    {
                        direction = acd;
                        simplex.RemoveAt(1);
                        simplexSize--;
                    }
                    else if (adb.DotProduct(a) > 0)
                    {
                        direction = adb;
                        simplex.RemoveAt(2);
                        simplexSize--;
                    }
                    else
                    {
                        return true;
                    }
                }

                return false;
            }

            var pointsA = (List<ThreeDimensionalPoint>)a.GetPoints(a.Matrix);
            var pointsB = (List<ThreeDimensionalPoint>)b.GetPoints(b.Matrix);

            var vectorAInit = new Vector(pointsA[0].XCoordinate, pointsA[0].YCoordinate, pointsA[0].ZCoordinate);
            var vectorBInit = new Vector(pointsB[0].XCoordinate, pointsB[0].YCoordinate, pointsB[0].ZCoordinate);

            int simplexSize = 0;
            Vector initialDirection = (Vector)vectorAInit.Subtract(vectorBInit);
            simplex[simplexSize++] = (Vector)Support(a, initialDirection).Subtract(Support(b, (Vector)initialDirection.ScalarMultiply(-1)));
            initialDirection = (Vector)simplex[0].ScalarMultiply(-1);

            while (true)
            {
                if (DoSimplex(ref simplexSize, ref initialDirection))
                {
                    return true;
                }

                if (simplex[0].DotProduct(initialDirection) <= 0)
                {
                    return false;
                }
            }
        }
        public bool DoCollide(Circle a, Circle b)
        {
            double distance = Math.Sqrt(Math.Pow(b.Center.XCoordinate - a.Center.XCoordinate, 2) + Math.Pow(b.Center.YCoordinate - a.Center.YCoordinate, 2));
            return distance <= (a.Radius + b.Radius);
        }
        public bool DoCollide(TwoDimensionalShape shapeA, TwoDimensionalShape shapeB)
        {
            var (min1, max1) = shapeA.GetBoundingBox();
            var (min2, max2) = shapeB.GetBoundingBox();

            bool intersect = min1.XCoordinate <= max2.XCoordinate && max1.XCoordinate >= min2.XCoordinate &&
                             min1.XCoordinate <= max2.XCoordinate && max1.XCoordinate >= min2.XCoordinate;
            return intersect;
        }

        public bool DoCollide(Sphere sphereA, Sphere sphereB)
        {
            double distance = Math.Sqrt(Math.Pow(sphereB.Center.XCoordinate - sphereA.Center.XCoordinate, 2)
                + Math.Pow(sphereB.Center.YCoordinate - sphereA.Center.YCoordinate, 2) + Math.Pow(sphereB.Center.ZCoordinate - sphereA.Center.ZCoordinate, 2));
            return distance <= (sphereA.Radius + sphereB.Radius);
        }

        public bool DoCollide(Sphere sphere, Plane plane)
        {
            var startPoint = (ThreeDimensionalPoint)plane.Vector.StartPoint;
            double distance = Math.Abs(startPoint.XCoordinate * sphere.Center.XCoordinate + startPoint.YCoordinate * sphere.Center.YCoordinate +
                                       startPoint.ZCoordinate * sphere.Center.ZCoordinate + plane.DistanceFromOrigin) /
                              Math.Sqrt(startPoint.XCoordinate * startPoint.XCoordinate + startPoint.YCoordinate * startPoint.YCoordinate + startPoint.ZCoordinate * startPoint.ZCoordinate);

            return distance <= sphere.Radius;
        }

        public bool DoCollide(Plane planeA, Plane planeB)
        {
            var startPointA = (ThreeDimensionalPoint)planeA.Vector.StartPoint;
            var startPointB = (ThreeDimensionalPoint)planeB.Vector.StartPoint;

            double crossProductX = startPointA.YCoordinate * startPointB.ZCoordinate - startPointA.ZCoordinate * startPointB.YCoordinate;
            double crossProductY = startPointA.ZCoordinate * startPointB.XCoordinate - startPointA.XCoordinate * startPointB.ZCoordinate;
            double crossProductZCoordinate = startPointA.XCoordinate * startPointB.YCoordinate - startPointA.YCoordinate * startPointB.XCoordinate;

            // If cross product is zero, planes are parallel
            var areParaller = Math.Abs(crossProductX) < double.Epsilon &&
                    Math.Abs(crossProductY) < double.Epsilon &&
                    Math.Abs(crossProductZCoordinate) < double.Epsilon;

            if (!areParaller)
                return false;

            double distance = Math.Abs(planeA.DistanceFromOrigin - planeB.DistanceFromOrigin);
            if (distance < double.Epsilon)
                return true;

            return false;
        }


        public bool DoCollide(
            ThreeDimensionalPoint pointA1,
            ThreeDimensionalPoint pointB1,
            ThreeDimensionalPoint pointA2,
            ThreeDimensionalPoint pointB2
            )
        {
            var startPointB = pointA1;
            var endPointB = pointA2;

            var p1 = pointB1;
            var endPointA = pointB2;

            double dXCoordinate1 = startPointB.XCoordinate - p1.XCoordinate;
            double dYCoordinate1 = startPointB.YCoordinate - p1.YCoordinate;
            double dZCoordinate1 = startPointB.ZCoordinate - p1.ZCoordinate;
            double dXCoordinate2 = endPointB.XCoordinate - endPointA.XCoordinate;
            double dYCoordinate2 = endPointB.YCoordinate - endPointA.YCoordinate;
            double dZCoordinate2 = endPointB.ZCoordinate - endPointA.ZCoordinate;

            // Check if lines are parallel
            double crossProductX = dYCoordinate1 * dZCoordinate2 - dZCoordinate1 * dYCoordinate2;
            double crossProductY = dZCoordinate1 * dXCoordinate2 - dXCoordinate1 * dZCoordinate2;
            double crossProductZCoordinate = dXCoordinate1 * dYCoordinate2 - dYCoordinate1 * dXCoordinate2;

            if (Math.Abs(crossProductX) < double.Epsilon &&
                Math.Abs(crossProductY) < double.Epsilon &&
                Math.Abs(crossProductZCoordinate) < double.Epsilon)
                return false;

            double t = ((endPointA.XCoordinate - p1.XCoordinate) * dYCoordinate2 * dZCoordinate1 + (endPointA.YCoordinate - p1.YCoordinate) * dZCoordinate2 * dXCoordinate1 + (endPointA.ZCoordinate - p1.ZCoordinate) * dXCoordinate2 * dYCoordinate1) /
                       (crossProductX + crossProductY + crossProductZCoordinate);

            double s = ((endPointA.XCoordinate - p1.XCoordinate) * dYCoordinate1 * dZCoordinate2 + (endPointA.YCoordinate - p1.YCoordinate) * dZCoordinate1 * dXCoordinate2 + (endPointA.ZCoordinate - p1.ZCoordinate) * dXCoordinate1 * dYCoordinate2) /
                       (crossProductX + crossProductY + crossProductZCoordinate);

            // Check if intersection point is within valid range (0 <= t, s <= 1)
            if (t >= 0 && t <= 1 && s >= 0 && s <= 1)
                return true;

            return false;
        }

        public bool DoCollide(
            TwoDimensionalPoint pointA1,
            TwoDimensionalPoint pointB1,
            TwoDimensionalPoint pointA2,
            TwoDimensionalPoint pointB2
            )
        {


            var startPointB = pointA1;
            var endPointB = pointA2;

            var p1 = pointB1;
            var endPointA = pointB2;

            float m1 = (startPointB.YCoordinate - p1.YCoordinate) / (startPointB.XCoordinate - p1.XCoordinate);
            float m2 = (endPointB.YCoordinate - endPointA.YCoordinate) / (endPointB.XCoordinate - endPointA.XCoordinate);

            if (Math.Abs(m1 - m2) < double.Epsilon)
                return false;

            float xIntersect = (m1 * p1.XCoordinate - m2 * endPointA.XCoordinate + endPointA.YCoordinate - p1.YCoordinate) / (m1 - m2);
            float yIntersect = m1 * (xIntersect - p1.XCoordinate) + p1.YCoordinate;

            // Check if intersection point lies within the ranges of both lines
            bool intersect = IsPointOnSegment(p1, startPointB, new TwoDimensionalPoint(xIntersect, yIntersect)) &&
                             IsPointOnSegment(endPointA, endPointB, new TwoDimensionalPoint(xIntersect, yIntersect));

            return intersect;

            bool IsPointOnSegment(TwoDimensionalPoint p, TwoDimensionalPoint q, TwoDimensionalPoint point)
            {
                if (point.XCoordinate >= Math.Min(p.XCoordinate, q.XCoordinate) && point.XCoordinate <= Math.Max(p.XCoordinate, q.XCoordinate) &&
                    point.YCoordinate >= Math.Min(p.YCoordinate, q.YCoordinate) && point.YCoordinate <= Math.Max(p.YCoordinate, q.YCoordinate))
                {
                    return true;
                }
                return false;
            }
        }


        public bool DoSegmentsCollide(
           TwoDimensionalPoint startPointA,
           TwoDimensionalPoint startPointB,
           TwoDimensionalPoint endPointA,
           TwoDimensionalPoint endPointB
           )
        {
            int o1 = Orientation(startPointA, startPointB, endPointA);
            int o2 = Orientation(startPointA, startPointB, endPointB);
            int o3 = Orientation(endPointA, endPointB, startPointA);
            int o4 = Orientation(endPointA, endPointB, startPointB);

            if (o1 != o2 && o3 != o4)
                return true;

            if (o1 == 0 && OnSegment(startPointA, endPointA, startPointB)) return true;
            if (o2 == 0 && OnSegment(startPointA, endPointB, startPointB)) return true;
            if (o3 == 0 && OnSegment(endPointA, startPointA, endPointB)) return true;
            if (o4 == 0 && OnSegment(endPointA, startPointB, endPointB)) return true;

            return false;


            int Orientation(TwoDimensionalPoint p, TwoDimensionalPoint q, TwoDimensionalPoint r)
            {
                double val = (q.YCoordinate - p.YCoordinate) * (r.XCoordinate - q.XCoordinate) - (q.XCoordinate - p.XCoordinate) * (r.YCoordinate - q.YCoordinate);

                if (Math.Abs(val) < double.Epsilon)
                    return 0;

                return (val > 0) ? 1 : 2;
            }

            bool OnSegment(TwoDimensionalPoint p, TwoDimensionalPoint q, TwoDimensionalPoint r)
            {
                if (q.XCoordinate <= Math.Max(p.XCoordinate, r.XCoordinate) && q.XCoordinate >= Math.Min(p.XCoordinate, r.XCoordinate) &&
                    q.YCoordinate <= Math.Max(p.YCoordinate, r.YCoordinate) && q.YCoordinate >= Math.Min(p.YCoordinate, r.YCoordinate))
                    return true;

                return false;
            }
        }

        public bool DoSegmentsCollide(
           ThreeDimensionalPoint startPointA,
           ThreeDimensionalPoint startPointB,
           ThreeDimensionalPoint endPointA,
           ThreeDimensionalPoint endPointB
           )
        {
            int o1 = Orientation(startPointA, endPointA, startPointB);
            int o2 = Orientation(startPointA, endPointA, endPointB);
            int o3 = Orientation(startPointB, endPointB, startPointA);
            int o4 = Orientation(startPointB, endPointB, endPointA);

            // General case
            if (o1 != o2 && o3 != o4)
                return true;

            if (o1 == 0 && OnSegment(startPointA, startPointB, endPointA)) return true;
            if (o2 == 0 && OnSegment(startPointA, endPointB, endPointA)) return true;
            if (o3 == 0 && OnSegment(startPointB, startPointA, endPointB)) return true;
            if (o4 == 0 && OnSegment(startPointB, endPointA, endPointB)) return true;

            return false;


            int Orientation(ThreeDimensionalPoint p, ThreeDimensionalPoint q, ThreeDimensionalPoint r)
            {
                double val = (q.YCoordinate - p.YCoordinate) * (r.XCoordinate - q.XCoordinate) - (q.XCoordinate - p.XCoordinate) * (r.YCoordinate - q.YCoordinate);

                if (Math.Abs(val) < double.Epsilon)
                    return 0;

                return (val > 0) ? 1 : 2;
            }

            bool OnSegment(ThreeDimensionalPoint p, ThreeDimensionalPoint q, ThreeDimensionalPoint r)
            {
                if (q.XCoordinate <= Math.Max(p.XCoordinate, r.XCoordinate) && q.XCoordinate >= Math.Min(p.XCoordinate, r.XCoordinate) &&
                        q.YCoordinate <= Math.Max(p.YCoordinate, r.YCoordinate) && q.YCoordinate >= Math.Min(p.YCoordinate, r.YCoordinate) &&
                        q.ZCoordinate <= Math.Max(p.ZCoordinate, r.ZCoordinate) && q.ZCoordinate >= Math.Min(p.ZCoordinate, r.ZCoordinate))
                    return true;

                return false;
            }
        }


        public static bool DoLineAndSegmentCollide(ThreeDimensionalPoint linePoint, ThreeDimensionalPoint lineDirection,
                                              ThreeDimensionalPoint segmentStartPoint, ThreeDimensionalPoint segmentEndPoint)
        {
            ThreeDimensionalPoint segmentDirection = (ThreeDimensionalPoint)segmentEndPoint.Subtract(segmentStartPoint);

            float t = ((segmentStartPoint.XCoordinate - linePoint.XCoordinate) * (segmentDirection.YCoordinate * lineDirection.ZCoordinate - segmentDirection.ZCoordinate * lineDirection.YCoordinate) +
                        (segmentStartPoint.YCoordinate - linePoint.YCoordinate) * (segmentDirection.ZCoordinate * lineDirection.XCoordinate - segmentDirection.XCoordinate * lineDirection.ZCoordinate) +
                        (segmentStartPoint.ZCoordinate - linePoint.ZCoordinate) * (segmentDirection.XCoordinate * lineDirection.YCoordinate - segmentDirection.YCoordinate * lineDirection.XCoordinate)) /
                       (lineDirection.XCoordinate * (segmentDirection.YCoordinate * lineDirection.ZCoordinate - segmentDirection.ZCoordinate * lineDirection.YCoordinate) +
                        lineDirection.YCoordinate * (segmentDirection.ZCoordinate * lineDirection.XCoordinate - segmentDirection.XCoordinate * lineDirection.ZCoordinate) +
                        lineDirection.ZCoordinate * (segmentDirection.XCoordinate * lineDirection.YCoordinate - segmentDirection.YCoordinate * lineDirection.XCoordinate));

            float u = ((segmentStartPoint.XCoordinate - linePoint.XCoordinate) * (lineDirection.YCoordinate * lineDirection.ZCoordinate) +
                        (segmentStartPoint.YCoordinate - linePoint.YCoordinate) * (lineDirection.ZCoordinate * lineDirection.XCoordinate) +
                        (segmentStartPoint.ZCoordinate - linePoint.ZCoordinate) * (lineDirection.XCoordinate * lineDirection.YCoordinate)) /
                       (lineDirection.XCoordinate * (segmentDirection.YCoordinate * lineDirection.ZCoordinate - segmentDirection.ZCoordinate * lineDirection.YCoordinate) +
                        lineDirection.YCoordinate * (segmentDirection.ZCoordinate * lineDirection.XCoordinate - segmentDirection.XCoordinate * lineDirection.ZCoordinate) +
                        lineDirection.ZCoordinate * (segmentDirection.XCoordinate * lineDirection.YCoordinate - segmentDirection.YCoordinate * lineDirection.XCoordinate));

            if (double.IsNaN(t) || double.IsNaN(u) || u < 0 || u > 1)
                return false;

            ThreeDimensionalPoint intersectionPoint = (ThreeDimensionalPoint)linePoint.Add(lineDirection.MultiplyByNumber(t));

            if (intersectionPoint.XCoordinate >= Math.Min(segmentStartPoint.XCoordinate, segmentEndPoint.XCoordinate) &&
                intersectionPoint.XCoordinate <= Math.Max(segmentStartPoint.XCoordinate, segmentEndPoint.XCoordinate) &&
                intersectionPoint.YCoordinate >= Math.Min(segmentStartPoint.YCoordinate, segmentEndPoint.YCoordinate) &&
                intersectionPoint.YCoordinate <= Math.Max(segmentStartPoint.YCoordinate, segmentEndPoint.YCoordinate) &&
                intersectionPoint.ZCoordinate >= Math.Min(segmentStartPoint.ZCoordinate, segmentEndPoint.ZCoordinate) &&
                intersectionPoint.ZCoordinate <= Math.Max(segmentStartPoint.ZCoordinate, segmentEndPoint.ZCoordinate))
            {
                return true;
            }

            return false;
        }

        public static bool DoLineAndSegmentCollide(TwoDimensionalPoint linePoint, TwoDimensionalPoint lineDirection,
                                              TwoDimensionalPoint segmentPoint1, TwoDimensionalPoint segmentPoint2)
        {
            int o1 = Orientation(linePoint, segmentPoint1, segmentPoint2);
            int o2 = Orientation(new TwoDimensionalPoint(linePoint.XCoordinate + lineDirection.XCoordinate, linePoint.YCoordinate + lineDirection.YCoordinate), segmentPoint1, segmentPoint2);
            int o3 = Orientation(segmentPoint1, segmentPoint2, linePoint);
            int o4 = Orientation(segmentPoint1, segmentPoint2, new TwoDimensionalPoint(linePoint.XCoordinate + lineDirection.XCoordinate, linePoint.YCoordinate + lineDirection.YCoordinate));

            if (o1 != o2 && o3 != o4)
                return true;

            if (o1 == 0 && IsPointOnSegment(linePoint, segmentPoint1, segmentPoint2))
                return true;

            return false;

            int Orientation(TwoDimensionalPoint p, TwoDimensionalPoint q, TwoDimensionalPoint r)
            {
                double val = (q.YCoordinate - p.YCoordinate) * (r.XCoordinate - q.XCoordinate) - (q.XCoordinate - p.XCoordinate) * (r.YCoordinate - q.YCoordinate);

                if (Math.Abs(val) < double.Epsilon)
                    return 0;

                return (val > 0) ? 1 : 2;
            }

            bool IsPointOnSegment(TwoDimensionalPoint p, TwoDimensionalPoint q1, TwoDimensionalPoint q2)
            {
                return p.XCoordinate <= Math.Max(q1.XCoordinate, q2.XCoordinate) && p.XCoordinate >= Math.Min(q1.XCoordinate, q2.XCoordinate) &&
                       p.YCoordinate <= Math.Max(q1.YCoordinate, q2.YCoordinate) && p.YCoordinate >= Math.Min(q1.YCoordinate, q2.YCoordinate);
            }
        }


        public static bool DoesSegmentIntersectPlane(ThreeDimensionalPoint segmentPoint1, ThreeDimensionalPoint segmentPoint2, Plane plane)
        {
            ThreeDimensionalPoint planePoint = (ThreeDimensionalPoint)plane.Vector.StartPoint;

            double length = Math.Sqrt(planePoint.XCoordinate * planePoint.XCoordinate + planePoint.YCoordinate * planePoint.YCoordinate + planePoint.ZCoordinate * planePoint.ZCoordinate);
            double planeA = planePoint.XCoordinate / length;
            double planeB = planePoint.YCoordinate / length;
            double planeC = planePoint.ZCoordinate / length;
            double planeD = plane.DistanceFromOrigin / length;

            double dot1 = planeA * segmentPoint1.XCoordinate + planeB * segmentPoint1.YCoordinate + planeC * segmentPoint1.ZCoordinate + planeD;
            double dot2 = planeA * segmentPoint2.XCoordinate + planeB * segmentPoint2.YCoordinate + planeC * segmentPoint2.ZCoordinate + planeD;

            if ((dot1 > 0 && dot2 < 0) || (dot1 < 0 && dot2 > 0))
                return true;

            return false; 
        }
    }
}
