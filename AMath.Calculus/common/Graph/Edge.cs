using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMath.Calculus.common.Graph
{
    public class Edge<T>
    {
        public int Source { get; set; }
        public int Destination { get; set; }
        public T Weight { get; set; }
    }
}
