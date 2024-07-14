using AMath.Calculus.common;
using AMath.Calculus.common.Points;
using AMath.Calculus.common.Points.Implementation;
using AMath.Calculus.Matrices;
using AMath.Calculus.Matrices.Implementation;
using AMath.Calculus.Vectors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMath.Calculus.Geometry.Implementation
{
    public class ThreeDimesnionalShape : BaseShape<float>
    {
        public ThreeDimesnionalShape(Matrix martix) : base(martix)
        {

        }

        public virtual float GetVolume()
        {
            var totalVolume = 0f;
            var points = (List<ThreeDimensionalPoint>)this.GetPoints(this.Matrix);
            var length = points.Count();
            var matrixBuilder = new MatrixBuilder();
            List<ThreeDimesnionalShape> tetrahedrons = new List<ThreeDimesnionalShape>();

            for (var i = 0; i < length; i++)
            {
                var tetrahedronPoints = new List<ThreeDimensionalPoint>()
                {
                    points[i],
                    points[(i + 1) % length],
                    points[(i + 2) % length],
                    points[(i + 3) % length]
                };

                var tetrahedronValues = new List<float>();

                tetrahedronPoints.ForEach(x => {
                    tetrahedronValues.AddRange(x.GetCoordinates().ToList());
                });

                var tetrahedronMatrix = matrixBuilder.Like(3, 4, tetrahedronValues.ToArray());

                tetrahedrons.Add(new ThreeDimesnionalShape((Matrix)tetrahedronMatrix));
            }

            var collisionDetector = new ShapeIntersectionChecker();
            var collisionTestDone = false;
            SortedSet<int> dublicatedIndices = new SortedSet<int>();
            while (!collisionTestDone)
            {
                collisionTestDone = true;
                for (var i = 0; i < tetrahedrons.Count(); i++)
                {
                    if (dublicatedIndices.Contains(i))
                        continue;
                    
                    for (var j = 0; j < tetrahedrons.Count(); j++)
                    {
                        if (dublicatedIndices.Contains(j))
                            continue;

                        try
                        {
                            if (collisionDetector.DoCollide(tetrahedrons[i], tetrahedrons[j]))
                            {
                                dublicatedIndices.Add(j);
                                collisionTestDone = false;
                            }
                        }catch (Exception ex)
                        {
                            collisionDetector.DoCollide(tetrahedrons[i], tetrahedrons[j]);
                            var b = 1;
                        }
                    }
                }
            }

            for (var i = 0; i < tetrahedrons.Count(); i++)
            {
                if (!dublicatedIndices.Contains(i))
                {
                    float det = tetrahedrons[i].Matrix.GetDeterminant();

                    totalVolume += Math.Abs(det) / 6;
                }
            }
            
            return totalVolume;
        }

        public override float GetSurfaceArea()
        {
            throw new NotImplementedException();
        }

        public override void GlideAndReflect(BaseVector<float> vector, float m, float c)
        {
            throw new NotImplementedException();
        }

        public override void Reflect(float m, float c)
        {
            throw new NotImplementedException();
        }

        public override void Rotate(int degree, Point<float> rotationPoint)
        {
            throw new NotImplementedException();
        }

        public override void Scale(Point<float> factors, Point<float> scaleBase)
        {
            throw new NotImplementedException();
        }

        public override void Translate(BaseVector<float> vector)
        {
            throw new NotImplementedException();
        }

        internal override IEnumerable<Point<float>> GetPoints(BaseMatrix<float> matrix)
        {
            // TODO: check if matrix is valid to represent two dimensional shape, if rowCount of it is 3

            var points = new List<ThreeDimensionalPoint>();

            for (int i = 0; i < matrix.ColumnCount; i++)
            {
                var column = matrix.GetColumn(i).ToArray();
                var point = new ThreeDimensionalPoint(column[0], column[1], column[2]);
                points.Add(point);
            }

            return points;
        }
    }
}
