using Course.Entities;
using Course.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter contract data");
            Console.WriteLine("Number:");
            int contractNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Date (dd/MM/yyyy):");
            DateTime contractDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine("Contract value:");
            double contractValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Enter number of installments:");
            int months = int.Parse(Console.ReadLine());

            Contract contract = new Contract(contractNumber, contractDate, contractValue);
            ContractService contractService = new ContractService(new PaypalService());
            contractService.ProcessContract(contract, months);

            Console.WriteLine("\nInstallments:");
            foreach (var installment in contract.Installments)
            {
                Console.WriteLine(installment);
            }
        }
    }
}
