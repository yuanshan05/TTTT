using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialEWpfDemo
{
    public class Student
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Phone { get; set; }


        public static List<Student> Initializer()
        {
            return new List<Student>
            {
                new Student{Name="张三",Age=18,Phone="15563718500"},
                new Student{Name="李四",Age=19,Phone="1558618326"},
                new Student{Name="王五",Age=43,Phone="13763718500"},
                new Student{Name="赵六",Age=43,Phone="17063725600"},
                new Student{Name="马云",Age=58,Phone="1556371203"},
                new Student{Name="马化腾",Age=32,Phone="1556371856"},
                new Student{Name="李彦宏",Age=17,Phone="155637185036"},
                new Student{Name="雷军",Age=18,Phone="15563716521"},
            };
        }
    }
}
