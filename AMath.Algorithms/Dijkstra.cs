using AMath.Calculus.Matrices.Implementation;
using System.Numerics;

// Source: http://matwbn.icm.edu.pl/ksiazki/cc/cc35/cc3536.pdf
namespace Algorithm.Algorithms
{
    public static class Dijkstra
    {
        public static List<int> ShortestPath(Matrix graph, int sourceIndex, int destinationIndex)
        {
            if (!graph.IsSquareMatrix)
                throw new Exception();
            #region Initialize
            int nodeCount = graph.RowCount;

            var distances = new List<float>();
            var previousNodes = new List<int>();
            var uncheckedNodes = new List<int>();

            for (int i = 0; i < nodeCount; i++)
            {
                distances.Add(float.MaxValue);
                previousNodes.Add(-1);
                uncheckedNodes.Add(i);
            }

            distances[sourceIndex] = 0f;
            int closetsNode = 0;
            #endregion

            for (int i = 0; i < nodeCount; i++)
            {
                closetsNode = ClosestNode(distances, uncheckedNodes);
                if (closetsNode == destinationIndex)
                    break;
                uncheckedNodes.Remove(closetsNode);

                for (int j = 0; j < uncheckedNodes.Count; j++)
                {
                    float distanceToUncheckedNode = graph.Get(closetsNode, uncheckedNodes[j]);
                    if (distanceToUncheckedNode <= 0)
                        continue;

                    float alternativeRouteLength = distances[closetsNode] + distanceToUncheckedNode;

                    if (alternativeRouteLength < distances[uncheckedNodes[j]])
                    {
                        distances[uncheckedNodes[j]] = alternativeRouteLength;
                        previousNodes[uncheckedNodes[j]] = closetsNode;
                    }
                }
            }

            var route = new List<int>();
            if (previousNodes[closetsNode] < 0 && closetsNode == sourceIndex)
                return route;
            else
            {
                while (previousNodes[closetsNode] >= 0)
                {
                    route.Add(closetsNode);
                    closetsNode = previousNodes[closetsNode];
                }
                route.Add(sourceIndex);
                route.Reverse();
                return route;
            }
        }

        private static int ClosestNode(List<float> distances, List<int> been)
        {
            float min = float.MaxValue;
            int index = 0;
            for (int i = 0; i < been.Count; i++)
            {
                float distance = distances[been[i]];
                if (distance < min)
                {
                    min = distance;
                    index = been[i];
                }
            }
            return index;
        }
    }
}