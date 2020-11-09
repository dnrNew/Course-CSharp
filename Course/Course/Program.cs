using System;
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

            void Teste4()
            {
                string path = @"C:\Temp\file1.txt";

                try
                {
                    using (StreamReader sr = File.OpenText(path))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            Console.WriteLine(line);
                        }
                    }
                }
                catch (IOException ex)
                {
                    Console.WriteLine("An error occurred");
                    Console.WriteLine(ex.Message);
                }
            }

            void Teste5()
            {
                string sourcePath = @"C:\Temp\file1.txt";
                string targetPath = @"C:\Temp\file2.txt";

                try
                {
                    string[] lines = File.ReadAllLines(sourcePath);

                    using (StreamWriter sw = File.AppendText(targetPath))
                    {
                        foreach (var line in lines)
                        {
                            sw.WriteLine(line.ToUpper());
                        }
                    }
                }
                catch (IOException ex)
                {
                    Console.WriteLine("An error occurred");
                    Console.WriteLine(ex.Message);
                }
            }

            void Teste6()
            {
                string path = @"C:\Temp";

                try
                {
                    var folders = Directory.EnumerateDirectories(path, "*.*", SearchOption.AllDirectories);
                    Console.WriteLine("Folders: ");
                    foreach (string s in folders)
                    {
                        Console.WriteLine(s);
                    }

                    var files = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);
                    Console.WriteLine("Files: ");
                    foreach (string s in files)
                    {
                        Console.WriteLine(s);
                    }

                    Directory.CreateDirectory(path + "\\NewFolder");
                    Directory.CreateDirectory(path + @"\NewFolder2");
                    Directory.CreateDirectory(@"C:\Temp\NewFolder3");
                }
                catch (IOException ex)
                {
                    Console.WriteLine("An error occurred");
                    Console.WriteLine(ex.Message);
                }
            }

            Teste7();

            void Teste7()
            {
                string path = @"C:\Temp\File5.txt";

                Console.WriteLine("DirectorySeparatorChar: " + Path.DirectorySeparatorChar);
                Console.WriteLine("PathSeparator: " + Path.PathSeparator);
                Console.WriteLine("GetDirectoryName: " + Path.GetDirectoryName(path));
                Console.WriteLine("GetFileName: " + Path.GetFileName(path));
                Console.WriteLine("GetExtension: " + Path.GetExtension(path));
                Console.WriteLine("GetFileNameWithoutExtension: " + Path.GetFileNameWithoutExtension(path));
                Console.WriteLine("GetFullPath: " + Path.GetFullPath(path));
                Console.WriteLine("GetTempPath: " + Path.GetTempPath());
            }
        }
    }
}
