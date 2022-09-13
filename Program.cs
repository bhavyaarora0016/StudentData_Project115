using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentData_Project115
{
    public class Student
    {
        public string name;
        public int classRoom;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Write  2. Read  3. Sort  4. Search");
            int choice = Convert.ToInt32(Console.ReadLine());
            var Details = File.ReadLines("StudentDataDemo.txt").OrderBy((line => (line.Split(',')[1]))).ToList();

            switch (choice)
            {
                case 1:
                    libWrite();
                    break;
                case 2:
                    libRead();
                    break;
                case 3:
                    Sort(Details);
                    break;
                case 4:
                    libSearch(Details);
                    break;
            }
        }

        private static void libSearch(List<string> Details)
        {
            bool found = false;
            Console.WriteLine("Enter a Name of the student you want to search :");
            string Stname = Console.ReadLine();

            foreach (var item in Details)
            {
                if (item.Split(',')[0].Equals(Stname))
                {
                    Console.WriteLine($"Student Name : {item.Split(',')[0]}\nClass Room : {item.Split(',')[1]}");
                    found = true;
                    break;
                }

            }
            if (!found)
            {
                Console.WriteLine("student not found in list.");
            }


        }

        private static void Sort(List<string> Details)
        {
            Details.Sort((a, b) => a.Split(',')[0].CompareTo(b.Split(',')[0]));

            foreach (var item in Details)
            {
                Console.WriteLine(item);
            }
        }

        private static void libRead()
        {
            FileStream f = new FileStream("StudentDataDemo.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(f);
            Console.WriteLine(sr.ReadToEnd());
        }

        private static void libWrite()
        {
            FileStream fs = new FileStream("StudentDataDemo.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            try
            {
                string name, classRoom, temp;
                bool status;
                do
                {
                    status = false;
                    Console.WriteLine("Enter Student Name:");
                    name = Console.ReadLine();
                    Console.WriteLine("Enter Classroom Number:");
                    classRoom = Console.ReadLine();
                    sw.WriteLine(name + "," + classRoom);
                    Console.WriteLine("continue? (y/n)");
                    temp = Console.ReadLine();
                    if (temp == "y" || temp == "Y")
                    {
                        status = true;
                    }
                } while (status);
            }
            finally
            {
                sw.Flush();
                sw.Close();
                fs.Close();
            }
        }


    }
    }
}}
