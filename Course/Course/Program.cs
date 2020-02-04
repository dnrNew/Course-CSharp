using Course.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Course
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<TaxPayer> listTaxPayer = new List<TaxPayer>();

            Console.Write("Enter the number of tax payers: ");
            int quantity = int.Parse(Console.ReadLine());

            for (int i = 1; i <= quantity; i++)
            {
                Console.WriteLine($"Tax payer #{i} data: ");
                Console.Write("Individual or company (i/c)? ");
                char typePayer = char.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Anual income: ");
                double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (typePayer == 'i')
                {
                    Console.Write("Health expenditures: ");
                    double healthExpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    listTaxPayer.Add(new Individual(name, anualIncome, healthExpenditures));
                }
                else if (typePayer == 'c')
                {
                    Console.Write("Number of employees: ");
                    int numberEmployees = int.Parse(Console.ReadLine());

                    listTaxPayer.Add(new Company(name, anualIncome, numberEmployees));
                }
            }

            Console.WriteLine();
            Console.WriteLine("TAXES PAID: ");

            var sumTaxPayer = 0.0;

            foreach (TaxPayer taxPayer in listTaxPayer)
            {
                taxPayer.AnualIncome = taxPayer.Tax();
                sumTaxPayer += taxPayer.AnualIncome;

                Console.WriteLine(
                    taxPayer.Name + ": $ " 
                    + taxPayer.AnualIncome.ToString("F2", CultureInfo.InvariantCulture));
            }

            Console.WriteLine();
            Console.WriteLine("TOTAL TAXES: $ " + sumTaxPayer.ToString("F2", CultureInfo.InvariantCulture));

            Console.ReadKey();
        }
    }
}
