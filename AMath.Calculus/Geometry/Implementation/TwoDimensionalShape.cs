using AMath.Calculus.common.Points;
using AMath.Calculus.common.Points.Implementation;
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

        public override void Rotate(int degree)
        {
            degree %= 360;

            if (degree == 0)
                return;

            var cosDegree = (float)Math.Cos(degree * (Math.PI / 180));
            var sinDegree = (float)Math.Cos(degree * (Math.PI / 180));
            var negativeSinDegree = (float)Math.Cos((degree * -1) * (Math.PI / 180));

            var rotationMatrix = new Matrix(new MatrixContent<float>(2, 2, new float[4] { cosDegree, negativeSinDegree, sinDegree, cosDegree }));

            Matrix = Matrix.Multiply(rotationMatrix);
        }

        public override void Scale(BaseVector<float> vector)
        {
            throw new NotImplementedException();
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
