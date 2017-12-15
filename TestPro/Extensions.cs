using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestPro
{
    public static class Extensions
    {
        public static bool IsPhone(this string value)
        {
            return Regex.IsMatch(value, @"^1[34578]\d{9}$");
        }

        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static string SubString(string value, int count = 10)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;

            int rows = value.Length / count;
            int cols = value.Length % count;

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < rows; i++)
            {
                sb.AppendLine(value.Substring(i * count, count));
            }

            if (cols > 0)
                sb.AppendLine(value.Substring(rows * count, cols));

            return sb.ToString();
        }


        public static void GetEnumerator<T>(this IEnumerator<T> values)
        {
            //return 
        }


    }
}
