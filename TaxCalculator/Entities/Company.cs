using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator.Entities
{
    class Company : TaxPayer
    {
        public int NumberOfEmployees { get; set; }

        public Company(string name, double yearlyIncome, int numberOfEmployees) : base
            (name, yearlyIncome)
        {
            NumberOfEmployees = numberOfEmployees;
        }

        public override double PayableTax()
        {
            if (NumberOfEmployees <= 10)
            {
                return YearlyIncome * 0.16;
            }
            else
            {
                return YearlyIncome * 0.14;
            }
        }
    }
}
