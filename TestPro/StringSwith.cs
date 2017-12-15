using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPro
{
    public class StringSwith
    {
        public static List<string> StringList = new List<string> { "A", "C", "B", "e", "F", "d", "g", "h" };

        public static void Init()
        {
            foreach (var item in StringList)
            {
                Swith(item);
            }
        }



        public static string Swith(string key)
        {
            string value = string.Empty;
            switch (key.FirstOrDefault().ToString().ToUpper())
            {
                case "A":
                    Console.WriteLine("A");
                    break;
                case "B":
                    Console.WriteLine("B");
                    break;
                case "C":
                    Console.WriteLine("C");
                    break;
                case "D":
                    Console.WriteLine("D");
                    break;
                case "E":
                    Console.WriteLine("E");
                    break;
                case "F":
                    Console.WriteLine("F");
                    break;
                case "G":
                    Console.WriteLine("G");
                    break;
                case "H":
                    Console.WriteLine("H");
                    break;
                default:
                    break;
            }

            return value;
        }
    }
}
