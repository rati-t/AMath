using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMath.Calculus.Matrices
{
    public static class MatrixExceptionHelper
    {
        public static Exception Build(RowOutOfRangeException exception)
        {
            return new ArgumentOutOfRangeException(message: String.Format("Provided row was out of range"), exception);
        }

        public static Exception Build(ColumnOutOfRangeException exception)
        {
            return new ArgumentOutOfRangeException(message: String.Format("Provided column was out of range"), exception);
        }

        public static Exception Build(MatricesIsNotCompatibleForAddition exception)
        {
            return new ArgumentOutOfRangeException(message: String.Format("Matrices can not be added"), exception);
        }

        public static Exception Build(MatricesIsNotCompatibleForSubtruction exception)
        {
            return new ArgumentOutOfRangeException(message: String.Format("Matrices can not be subtructed"), exception);
        }

        public static Exception Build(MatricesIsNotCompatibleForMultiplication exception)
        {
            return new ArgumentOutOfRangeException(message: String.Format("Matrices can not be multiplied"), exception);
        }
    }

    public class RowOutOfRangeException : Exception
    {

    }

    public class ColumnOutOfRangeException : Exception
    {

    }

    public class MatricesIsNotCompatibleForAddition : Exception
    {

    }

    public class MatricesIsNotCompatibleForSubtruction : Exception
    {

    }

    public class MatricesIsNotCompatibleForMultiplication : Exception
    {

    }
}
