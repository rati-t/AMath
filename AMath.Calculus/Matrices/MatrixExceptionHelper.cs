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

        public static Exception Build(MatrixAndRowNotCompatibleForAddition exception)
        {
            return new ArgumentOutOfRangeException(message: String.Format("Row can not be added to matrix"), exception);
        }

        public static Exception Build(MatrixAndColumnNotCompatibleForAddition exception)
        {
            return new ArgumentOutOfRangeException(message: String.Format("Column can not be added to matrix"), exception);
        }

        public static Exception Build(MatricesIsNotCompatibleForSubtruction exception)
        {
            return new ArgumentOutOfRangeException(message: String.Format("Matrices can not be subtructed"), exception);
        }

        public static Exception Build(MatrixAndRowCompatibleForSubtruction exception)
        {
            return new ArgumentOutOfRangeException(message: String.Format("Row can not be subtructed from matrix"), exception);
        }

        public static Exception Build(MatrixAndColumnCompatibleForSubtruction exception)
        {
            return new ArgumentOutOfRangeException(message: String.Format("Column can not be subtructed from matrix"), exception);
        }

        public static Exception Build(MatricesIsNotCompatibleForMultiplication exception)
        {
            return new ArgumentOutOfRangeException(message: String.Format("Matrices can not be multiplied"), exception);
        }

        public static Exception Build(MatrixAndRowNotCompatibleForMultiplication exception)
        {
            return new ArgumentOutOfRangeException(message: String.Format("Row and matrix can not be multiplied"), exception);
        }

        public static Exception Build(MatrixAndColumnNotCompatibleForMultiplication exception)
        {
            return new ArgumentOutOfRangeException(message: String.Format("Column and matrix can not be multiplied"), exception);
        }
        
        public static Exception Build(MatricesIsNotCompatibleForDivison exception)
        {
            return new ArgumentOutOfRangeException(message: String.Format("Matrices is not comaptible for divison"), exception);
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

    public class MatrixAndRowNotCompatibleForAddition : Exception
    {

    }

    public class MatrixAndColumnNotCompatibleForAddition : Exception
    {

    }

    public class MatricesIsNotCompatibleForSubtruction : Exception
    {

    }

    public class MatrixAndRowCompatibleForSubtruction : Exception
    {

    }
    public class MatrixAndColumnCompatibleForSubtruction : Exception
    {

    }


    public class MatricesIsNotCompatibleForMultiplication : Exception
    {

    }

    public class MatrixAndRowNotCompatibleForMultiplication : Exception
    {

    }

    public class MatrixAndColumnNotCompatibleForMultiplication : Exception
    {

    }

    public class MatricesIsNotCompatibleForDivison : Exception
    {

    }
}
