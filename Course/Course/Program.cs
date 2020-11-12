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
            Console.WriteLine("Enter rental data");
            Console.WriteLine("Car model:");
            string model = Console.ReadLine();

            Console.WriteLine("Pickup (dd/MM/yyyy hh:mm):");
            DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            Console.WriteLine("Return (dd/MM/yyyy hh:mm):");
            DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            Console.WriteLine("Enter price per hour: ");
            double hour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Enter price per day: ");
            double day = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            CarRental carRental = new CarRental(start, finish, new Vehicle(model));
            RentalServices rentalServices = new RentalServices(hour, day);
            rentalServices.ProcessInvoice(carRental);

            Console.WriteLine("\nINVOICE:");
            Console.WriteLine(carRental.Invoice);
        }
    }
}
