using AMath.Calculus.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMath.Algorithms
{
    public class NegativeCycleException : Exception
    {
        public NegativeCycleException(int[] negativeCycleVertices)
            : base(message: string.Format("Vertices {0} forms negative cycle in graph", negativeCycleVertices.GetDelimiteredItems(',')))
        {
        }
    }
}
