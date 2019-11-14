using System;
using System.Globalization;

namespace Course.Entities
{
    class Company : TaxPayer
    {
        public int NumberOfEmployees { get; set; }

        public Company(string name, double anualIncome, int numberOfEmployees) : base(name, anualIncome)
        {
            NumberOfEmployees = numberOfEmployees;
        }

        public override double Tax()
        {
            var tax = NumberOfEmployees > 10 ? 0.14 : 0.16;

            return AnualIncome * tax;
        }
    }
}
