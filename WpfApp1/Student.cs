using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        private static string key = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; //26

        public static List<Student> CreateStudents(int count)
        {
            List<Student> students = new List<Student>();
            for (int i = 0; i < count; i++)
            {
                Random rdm = new Random(i);
                Student student = new Student
                {
                    Id = i,
                    Name = GetName(rdm,key),
                    Phone = GetPhone(rdm),
                };
                students.Add(student);
            }
            return students;
        }

        static string GetName(Random rdm,string name)
        {
            int index = rdm.Next(0, name.Length);
            int step = rdm.Next(0, name.Length - 1 - index);
            int checkKey = rdm.Next(100, 999);

            return $"{name.Substring(index, step)}{checkKey}";
        }

        static string GetPhone(Random rdm)
        {
            //Random rdm = new Random(int.MaxValue);
            string phone = "1";
            for (int i = 0; i < 10; i++)
            {
                phone = phone + rdm.Next(1, 9).ToString();
            }
            return phone;
        }
    }
}
