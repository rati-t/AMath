using AMath.Calculus.common;
using AMath.Calculus.common.Points;
using AMath.Calculus.common.Points.Implementation;
using AMath.Calculus.common.Trigonometry;
using AMath.Calculus.Matrices;
using AMath.Calculus.Matrices.Implementation;
using AMath.Calculus.Vectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMath.Calculus.Geometry.Implementation
{
    public class TwoDimensionalShape : BaseShape<float>
    {
        public TwoDimensionalShape(Matrix martix) : base(martix)
        {
            
        }

        public virtual float GetPerimeter()
        {
            double result = 0;
            var points = (List<TwoDimensionalPoint>)this.GetPoints(this.Matrix);
            var length = points.Count();
            for (var i = 0; i < length; i++)
            {
                var source = points[i];
                var dest = points[(i + 1) % length];
                var distance = Helper.GetHypotenuse((double)(source.XCoordinate - dest.XCoordinate), (double)(source.YCoordinate - dest.YCoordinate));

                result += distance;
            }
            return (float)result;
        }

        public override float GetSurfaceArea()
        {
            float area = 0;
            var points = (List<TwoDimensionalPoint>)this.GetPoints(this.Matrix);
            var length = points.Count();
            for (var i = 0; i < length; i++)
            {
                var source = points[i];
                var dest = points[(i + 1) % length];

                area += source.XCoordinate * dest.YCoordinate;
                area -= source.YCoordinate * dest.XCoordinate;
            }

            return Math.Abs(area) / 2;
        }

        public override void GlideAndReflect(BaseVector<float> vector, float m, float c)
        {
            Translate(vector);
            Reflect(m, c);
        }

        public override void Reflect(float m, float c)
        {
            for (int i = 0; i < Matrix.ColumnCount; i++)
            {
                var column = Matrix.GetColumn(i).ToArray();

                var x = column[0];
                var y = column[1];

                var d = (x + (y - c) * m) / (1 + (float)Math.Pow(m, 2));

                var x2 = 2 * d - x;
                var y2 = 2 * d * m - y + 2 * c;

                Matrix.SetColumn(new float[] { x2, y2 }, i);
            }
        }

        public override void Rotate(int degree, Point<float> rotationPoint)
        {
            if(!rotationPoint.IsOrigin())
                this.Translate(new Vector(rotationPoint.XCoordinate * -1, rotationPoint.YCoordinate * -1));

            degree %= 360;

            if (degree == 0)
                return;

            var cosDegree = (float)TrigonometryExtension.Cos(degree * Math.PI / 180);
            var sinDegree = (float)TrigonometryExtension.Sin(degree * Math.PI / 180);
            var negativeSinDegree = (float)TrigonometryExtension.Sin(degree * -1 * Math.PI / 180);

            var rotationMatrix = new Matrix(new MatrixContent<float>(2, 2, new float[4] { cosDegree, negativeSinDegree, sinDegree, cosDegree }));

            Matrix = Matrix.Multiply(rotationMatrix);

            if (!rotationPoint.IsOrigin())
                this.Translate(new Vector(rotationPoint.XCoordinate, rotationPoint.YCoordinate));
        }

        public override void Scale(Point<float> factor, Point<float> scaleBase)
        {
            if(!scaleBase.IsOrigin())
                this.Translate(new Vector(scaleBase.XCoordinate * -1, scaleBase.YCoordinate * -1));

            var scalingMatrix = new Matrix(new MatrixContent<float>(2, 2, new float[4] { factor.XCoordinate, 0, 0, factor.YCoordinate }));

            Matrix = Matrix.Multiply(scalingMatrix);

            if (!scaleBase.IsOrigin())
                this.Translate(new Vector(scaleBase.XCoordinate, scaleBase.YCoordinate));
        }

        public override void Translate(BaseVector<float> vector)
        {
            var horizontalShift = vector.EndPoint.XCoordinate - vector.StartPoint.XCoordinate;
            var verticalShift = vector.EndPoint.YCoordinate - vector.StartPoint.YCoordinate;

            Matrix.AddToRow(horizontalShift, 0);
            Matrix.AddToRow(verticalShift, 1);
        }



        internal override IEnumerable<Point<float>> GetPoints(BaseMatrix<float> matrix)
        {
            // TODO: check if matrix is valid to represent two dimensional shape, if rowCount of it is 2

            var points = new List<TwoDimensionalPoint>();

            for (int i = 0; i < matrix.ColumnCount; i++)
            {
                var column = matrix.GetColumn(i).ToArray();
                var point = new TwoDimensionalPoint(column[0], column[1]);
                points.Add(point);
            }

            return points;
        }
    }
}
