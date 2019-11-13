using System;
using System.Globalization;

namespace Course.Entities
{
    class Company : TaxPayer
    {
        public int NumberOfEmployees { get; set; }

        public Company(int numberOfEmployees, string name, double anualIncome) : base (name, anualIncome)
        {
            NumberOfEmployees = numberOfEmployees;
        }

        public override double Tax()
        {
            return 0;
        }

        //public override string PriceTag()
        //{
        //    return Name
        //        + " (used) $ "
        //        + Price.ToString("F2", CultureInfo.InvariantCulture)
        //        + $" (Manufacture date: {ManufactureDate.ToString("dd/MM/yyyy")})";
        //}
    }
}
