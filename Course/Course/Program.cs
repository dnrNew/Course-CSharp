using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            void Teste1()
            {
                string sourcePath = @"C:\Temp\file1.txt";
                string targetPath = @"C:\Temp\file2.txt";

                try
                {
                    FileInfo fileInfo = new FileInfo(sourcePath);
                    fileInfo.CopyTo(targetPath);

                    string[] lines = File.ReadAllLines(sourcePath);

                    foreach (string line in lines)
                    {
                        Console.WriteLine();
                    }

                }
                catch (IOException ex)
                {
                    Console.WriteLine("An error occurred");
                    Console.WriteLine(ex.Message);
                }
            }

            void Teste2()
            {
                string path = @"C:\Temp\file1.txt";
                FileStream fs = null;
                StreamReader sr = null;

                try
                {
                    fs = new FileStream(path, FileMode.Open);
                    sr = new StreamReader(fs);

                    string line = sr.ReadLine();
                    Console.WriteLine(line);
                }
                catch (IOException ex)
                {
                    Console.WriteLine("An error occurred");
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (sr != null) sr.Close();
                    if (fs != null) sr.Close();
                }
            }

            Teste3();

            void Teste3()
            {
                string path = @"C:\Temp\file1.txt";
                StreamReader sr = null;

                try
                {
                    sr = File.OpenText(path);

                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        Console.WriteLine(line);
                    }
                }
                catch (IOException ex)
                {
                    Console.WriteLine("An error occurred");
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (sr != null) sr.Close();
                }
            }
        }
    }
}
