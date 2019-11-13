using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Course.Entities
{
    class Individual : TaxPayer
    {
        public double HealthExpenditures{ get; set; }

        public Individual(double healthExpenditures, string name, double anualIncome) : base (name, anualIncome)
        {
            HealthExpenditures = healthExpenditures;
        }

        public override double Tax()
        {
            return 0;
        }
    }
}
