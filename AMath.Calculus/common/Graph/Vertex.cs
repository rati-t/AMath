using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMath.Calculus.common.Graph
{
    public class Vertex<T>
    {
        public Vertex()
        {
            Edges = new List<Edge<T>>();
        }
        public List<Edge<T>> Edges { get; set; }
    }
}
