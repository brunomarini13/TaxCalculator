using System;
using System.Globalization;
using System.Collections.Generic;
using TaxCalculator.Entities;

namespace TaxCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Tax Calculator, rules:
              Company taxes --> general rule: 16% of income, but goes down to 14% 
              if company has more than 10 employees
              Individual rules --> if income is lower than 20.000, taxes are 15%
              More than 20.000, taxes are 25%. In both individual cases, you can deduct
              50% of health expenses from the amount of taxes calculated.
            */

            List<TaxPayer> list = new List<TaxPayer>();

            Console.Write("Enter the number of tax payers: ");
            int taxPayers = int.Parse(Console.ReadLine());

            for (int i = 1; i <= taxPayers; i++)
            {
                Console.WriteLine($"Tax payer #{i} data:");
                Console.Write("Individual or company (i/c)? ");
                char typeOfTaxPayer = char.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Annual income: ");
                double annualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (typeOfTaxPayer == 'i')
                {
                    Console.Write("Health expenditures: ");
                    double healthExpenses = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    list.Add(new Individual(name, annualIncome, healthExpenses));
                }
                else
                {
                    Console.Write("Number of employees: ");
                    int numberOfEmployees = int.Parse(Console.ReadLine());

                    list.Add(new Company(name, annualIncome, numberOfEmployees));
                }
            }
            Console.WriteLine();
            Console.WriteLine("TAXES PAID:");

            foreach (TaxPayer taxpayer in list)
            {
                
                Console.WriteLine(taxpayer.Name + ": $ " + 
                    taxpayer.PayableTax().ToString("F2", CultureInfo.InvariantCulture));
            }
            Console.WriteLine();

            double totalTaxes = 0.0;

            foreach (TaxPayer taxpayer in list)
            {
                totalTaxes += taxpayer.PayableTax();
            }

            Console.WriteLine("TOTAL TAXES: $ " + totalTaxes.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
