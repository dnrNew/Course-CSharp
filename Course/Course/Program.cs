using Course.Entities;
using System;
using System.Collections.Generic;
using System.IO;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = @"C:\Temp\in.csv";

            try
            {
                using(StreamReader sr = File.OpenText(path))
                {
                    List<Employee> list = new List<Employee>();

                    while (!sr.EndOfStream)
                    {
                        list.Add(new Employee(sr.ReadLine()));
                    }

                    list.Sort();

                    foreach (var employee in list)
                    {
                        Console.WriteLine(employee);
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("An error ocurred");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
