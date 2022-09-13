using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentData_Project115
{
    internal class libSearch
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter student name: ");
            string name = Console.ReadLine();

            var Details = File.ReadLines("StudentDataDemo.txt").OrderBy((line => (line.Split(',')[1]))).ToList();

            bool found = false;

            foreach (var item in Details)
            {
                Console.WriteLine("searching the list.....");
                if (item.Contains(name))
                {
                    Console.WriteLine($"Name: {item.Split(',')[0]}");
                    Console.WriteLine($"class room number: {item.Split(',')[1]}");
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("student not found in list.");
                Console.WriteLine("enter valid name");
            }
        }
    }
}
