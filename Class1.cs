using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StudentData_Project115
{
    public class Class1
    {
        static void Main(string[] args)
        {
            File.Create("StudentData.txt");

            Console.WriteLine("enter details: ");
            string st = Console.ReadLine();

            File.AppendAllText("StudentData.txt", "\n" + st);

            List<Student> list = new List<Student>();
            list = ReadFile();

            foreach (var item in list)
            {
                Console.WriteLine(item.name);
            }

            var Details = File.ReadLines("StudentData.txt").OrderBy((line => (line.Split(',')[0]))).ToList();

            foreach (var item in Details)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("---------------");

            list.Sort((a, b) => a.name[1].CompareTo(b.name[1]));

            foreach (var item in list)
            {
                Console.WriteLine(item.name + " " + item.classRoom);
            }
        }

        public static List<Student> ReadFile()
        {
            List<Student> details;
            string[] data = File.ReadAllLines("StudentData.txt");

            if (data != null)
            {
                Student stud;
                string[] temp;

                details = new List<Student>();

                for (int i = 0; i < data.GetLength(0); i++)
                {
                    temp = Regex.Split(data[i], ",");

                    if (temp != null && temp.GetLength(0) > 1)
                    {
                        stud = new Student();
                        stud.name = temp[0];
                        int.TryParse(temp[1], out stud.classRoom);
                        details.Add(stud);
                    }
                }
                return details.ToList();
            }
            return null;
        }
    }
}