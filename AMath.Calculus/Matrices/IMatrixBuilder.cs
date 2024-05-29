﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMath.Calculus.Matrices
{
    public abstract class IMatrixBuilder<T>
        where T : struct, IEquatable<T>
    {
        public abstract IMatrix<T> Like(int rows, int columns);
    }
}
