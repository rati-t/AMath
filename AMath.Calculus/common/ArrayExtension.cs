using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMath.Calculus.common
{
    public static class ArrayExtension
    {
        public static string GetDelimiteredItems<T>(this T[] items, char delimiter)
        {
            var strBuilder = new StringBuilder();

            foreach (var item in items)
            {
                if (item == null)
                    continue;

                strBuilder.Append(item.ToString());
                strBuilder.Append(delimiter);
            }

            return strBuilder.ToString();
        }
    }
}
