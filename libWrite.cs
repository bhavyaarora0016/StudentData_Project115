using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentData_Project115
{
    internal class libWrite
    {
        static void Main(string[] args)
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
                    Console.WriteLine("enter student name: ");
                    name = Console.ReadLine();

                    Console.WriteLine("enter classroom number: ");
                    classRoom = Console.ReadLine();

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
