using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator.Entities
{
    class Individual : TaxPayer
    {
        public double HealthExpenses { get; set; }

        public Individual(string name, double yearlyIncome, double healthExpenses) : base
            (name, yearlyIncome)
        {
            HealthExpenses = healthExpenses;
        }

        public override double PayableTax()
        {
            if (YearlyIncome < 20000)
            {
                return YearlyIncome * 0.15 - HealthExpenses * 0.5;
            }
            else
            {
                return YearlyIncome * 0.25 - HealthExpenses * 0.5;
            }
        }
    }
}
