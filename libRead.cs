using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentData_Project115
{
    internal class libRead
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream("StudentDataDemo.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            Console.WriteLine(sr.ReadToEnd());
        }
    }
}
