using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Course.Entities
{
    class Individual : TaxPayer
    {
        public double HealthExpenditures{ get; set; }

        public Individual(string name, double anualIncome, double healthExpenditures) : base (name, anualIncome)
        {
            HealthExpenditures = healthExpenditures;
        }

        public override double Tax()
        {
            var tax = AnualIncome <= 20000.00 ? 0.15 : 0.25;
            AnualIncome = AnualIncome * tax;

            if (HealthExpenditures > 0)
                AnualIncome = AnualIncome - (HealthExpenditures * 0.5);

            return AnualIncome;
        }
    }
}
