using AMath.Calculus.Matrices.Implementation;

namespace Algorithm.PathFinding
{
    public static class Bellman
    {
        public static List<int> ShortestPath(Matrix graph, int sourceIndex, int destinationIndex)
        {
            #region Initialization
            var nodeCount = graph.RowCount;

            var distances = new List<float>();
            var predecessor = new List<int>();

            for (int i = 0; i < nodeCount; i++) 
            {
                distances.Add(float.MaxValue);
                predecessor.Add(-1);
            }
            distances[sourceIndex] = 0;
            #endregion

            for (int i = 1; i < nodeCount - 1; i++)
            {
                for (int j = 0; j < nodeCount - 1 && i != j; j++)
                {
                    float weight = graph.Get(i, j);
                    if (weight == 0 || distances[i] + weight >= distances[j])
                        continue;

                    distances[j] = distances[i] + weight;
                    predecessor[j] = i;
                }
            }



            return new List<int>();
        }
    }
}
