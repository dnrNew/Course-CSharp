using Course.Entities;
using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string sourceFilePath = @"C:\Temp\Vendas.csv";               
                string[] lines = File.ReadAllLines(sourceFilePath);
                string sourceFolderPath = Path.GetDirectoryName(sourceFilePath);
                string targetFolderPath = sourceFolderPath + @"\out";
                string targetFilePath = targetFolderPath + @"\summary.csv";

                Directory.CreateDirectory(targetFolderPath);

                using (StreamWriter sw = File.AppendText(targetFilePath))
                {
                    foreach (string line in lines)
                    {
                        string[] fields = line.Split(',');
                        string name = fields[0];
                        double price = double.Parse(fields[1], CultureInfo.InvariantCulture);
                        int quantity = int.Parse(fields[2]);

                        Product product = new Product(name, price, quantity);

                        sw.WriteLine(product.Name + "," + product.Total().ToString("F2", CultureInfo.InvariantCulture));
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("An error occurred: ");
                Console.WriteLine(ex.Message);
            }



        }
    }
}
