using Course.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> listProducts = new List<Product>();

            Console.Write("Enter the number of products: ");
            int quantity = int.Parse(Console.ReadLine());

            for (int i = 1; i <= quantity; i++)
            {
                Console.WriteLine($"Product #{i} data: ");
                Console.Write("Common, used or imported (c/u/i)? ");
                char typeProduct = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (typeProduct == 'i')
                {
                    Console.Write("Customs fee: ");
                    double customsFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    listProducts.Add(new ImportedProduct(name, price, customsFee));
                }
                else if (typeProduct == 'u')
                {
                    Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateTime manufacturedDate = DateTime.Parse(Console.ReadLine());

                    listProducts.Add(new UsedProduct(name, price, manufacturedDate));
                }
                else
                    listProducts.Add(new Product(name, price));
            }

            Console.WriteLine();
            Console.WriteLine("PRICE TAGS:");

            foreach (Product product in listProducts)
            {
                Console.WriteLine(product.PriceTag());
            }

            Console.ReadKey();
        }
    }
}
