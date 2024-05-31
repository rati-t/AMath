using AMath.Calculus.common.Graph;
using AMath.Calculus.Matrices;
using AMath.Calculus.Matrices.Implementation;
using System.Diagnostics.Metrics;

namespace AMath.Algorithms
{
    public static class Bellman
    {
        public static List<int> ShortestPath(Matrix graph, int sourceIndex, int destinationIndex)
        {
            var edges = graph.GetEdges();
            BellManResult<float> bellmanResult = DoesNegativeCycleExist(edges, graph.RowCount, sourceIndex, destinationIndex);

            if (bellmanResult == null)
                throw new Exception();

            if (bellmanResult.ContainsNegativeCycle)
                throw new NegativeCycleException(bellmanResult.NegativeCycleVertices);

            return bellmanResult.Route;
        }

        private static BellManResult<float> DoesNegativeCycleExist(List<Edge<float>> edges, int verticesCount, int source, int destination)
        {
            List<int> negCycleVertices = new List<int>();

            // Initializaiton
            var path = new List<int>();
            float[] dist = new float[verticesCount];
            int[] prev = new int[verticesCount];
            Array.Fill(dist, float.MaxValue);
            dist[source] = 0;

            // relaxation for N - 1 
            for (int k = 0; k < verticesCount - 1; k++)
            {
                foreach (var edge in edges)
                {
                    int src = edge.Source;
                    int dest = edge.Destination;
                    float weight = edge.Weight;

                    if (dist[src] + weight < dist[dest])
                    {
                        dist[dest] = dist[src] + weight;
                        prev[dest] = src;
                    }
                }
            }

            // Nth relaxation
            foreach (var edge in edges)
            {
                int src = edge.Source;
                int dest = edge.Destination;
                float weight = edge.Weight;

                // if true, Negative Cycle exist
                if (dist[src] + weight < dist[dest])
                {
                    negCycleVertices.Add(dest);
                    negCycleVertices.Add(src);
                }
            }

            negCycleVertices = negCycleVertices.Distinct().ToList();

            if (negCycleVertices.Count > 0)
                return new BellManResult<float>(true, negCycleVertices.ToArray(), dist, path);

            int current = destination;
            while (current != source)
            {
                path.Add(current);
                current = prev[current];
            }

            path.Reverse();

            return new BellManResult<float>(false, negCycleVertices.ToArray(), dist, path);
        }

        private class BellManResult<T>
        {
            public BellManResult(bool containsNegativeCycle, int[] negativeCycleVertices, T[] distancesFromSource, List<int> route)
            {
                ContainsNegativeCycle = containsNegativeCycle;
                NegativeCycleVertices = negativeCycleVertices;
                DistancesFromSource = distancesFromSource;
                Route = route;

            }
            public bool ContainsNegativeCycle { get; set; }
            public int[] NegativeCycleVertices { get; set; }
            public T[] DistancesFromSource { get; set; }
            public List<int> Route { get; set; }    
        }
    }
}

