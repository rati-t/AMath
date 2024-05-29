using AMath.Calculus.common.Points;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AMath.Calculus.Vectors
{
    public class Vector<T> where T : struct, IEquatable<T>
    {
        internal Point<T> StartPoint { get; set; }
        internal Point<T> EndPoint { get; set; }
        
        public Vector(T startX, T startY, T endX, T endY) 
        {  
            StartPoint = new TwoDimensionalPoint<T>(startX, startY); 
            EndPoint = new TwoDimensionalPoint<T>(endX, endY); 
        }

        public static Vector<T> operator + (Vector<T> first, Vector<T> second)
        {
            return null;
        }
    }
}
