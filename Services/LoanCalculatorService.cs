using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanCalculator2._0.Models;

namespace LoanCalculator2._0.Services
{
    public class LoanCalculatorService
    {
        public LoanCalculationResponse CalculateLoan (LoanCalculationRequest request)
        {
            //Convert annual interest rate to decimal form
            double monthlyInterestRate = request.AnnualInterestRate/100/12;

            //Monthly payment 
            decimal monthlyPayment = request.Principal * (decimal)(monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, request.AnnualInterestRate)/
            (Math.Pow(monthlyInterestRate, request.AnnualInterestRate)-1));

            //Total payment over the entire loan period
            decimal totalPayment = monthlyPayment * request.LoanTenureMonths;

            //Total Interest paid
            decimal totalInterest = totalPayment - request.Principal;

            return new LoanCalculationResponse
            {
            MonthlyPayment = monthlyPayment,
            TotalPayment = totalPayment,
            TotalInterest = totalInterest
            };
            
        }
    }
}