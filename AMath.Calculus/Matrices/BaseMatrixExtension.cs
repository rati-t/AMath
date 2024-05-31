using AMath.Calculus.common.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMath.Calculus.Matrices
{
    public static class BaseMatrixExtension
    {
        /// <summary>
        /// Gets vertices Based on logic that non intersection is default value of T generic
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="graph"></param>
        /// <returns></returns>
        public static List<Vertex<T>> GetVertices<T>(this BaseMatrix<T> graph) where T : struct, IEquatable<T>
        {
            var vertices = new List<Vertex<T>>();

            for (int j = 0; j < graph.ColumnCount; j++)
            {
                Vertex<T> vertex = new Vertex<T>();
                T[] weights = graph.GetColumn(j).ToArray();
                for (int i = 0; i < weights.Count(); i++)
                {
                    if (!weights[i].Equals(default(T)))
                        vertex.Edges.Add(new Edge<T>()
                        {
                            Source = i,
                            Destination = i,
                            Weight = weights[i]
                        });
                }

                vertices.Add(vertex);
            }

            return vertices;
        }

        /// <summary>
        /// Gets Edges Based on logic that non intersection is default value of T generic
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="graph"></param>
        /// <returns></returns>
        public static List<Edge<T>> GetEdges<T>(this BaseMatrix<T> graph) where T : struct, IEquatable<T>
        {
            var edges = new List<Edge<T>>();

            for (int i = 0; i < graph.RowCount; i++)
            {
                for (int j = 0; j < graph.ColumnCount; j++)
                {
                    T weight = graph.Get(i, j);
                    if (!weight.Equals(default(T)))
                    {
                        edges.Add(new Edge<T>()
                        {
                            Source = j,
                            Destination = i,
                            Weight = weight
                        });
                    }
                }
            }

            return edges;
        }
    }
}
