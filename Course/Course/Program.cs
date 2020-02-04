using Course.Entities;
using Course.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Course
{
    class ProcessFile
    {
        public static void Main(string[] args)
        {
            try
            {
                Account account = new Account();

                Console.WriteLine("Enter account data: ");
                Console.Write("Number: ");
                account.Number = int.Parse(Console.ReadLine());

                Console.Write("Holder: ");
                account.Holder = Console.ReadLine();

                Console.Write("Initial balance: ");
                account.Balance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Withdraw limit: ");
                account.WithdrawLimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Enter amount for withdraw: ");
                double amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                account.Withdraw(amount);

                Console.WriteLine();
                Console.WriteLine("New balance:" + account.Balance.ToString("F2", CultureInfo.InvariantCulture));

                Console.ReadKey();
            }
            catch (DomainException ex)
            {
                Console.WriteLine("Withdraw error: " + ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Format error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
            }
        }
    }
}
