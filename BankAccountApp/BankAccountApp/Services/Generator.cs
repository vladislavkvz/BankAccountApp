namespace BankAccountApp.Services
{
    using BankAccountApp.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    public class Generator : IInterestRate
    {
        public static string GenerateUniqueFiveDigit()
        {
            string num = "";
            bool isUnique = false;

            Random rand = new Random();
            while (!isUnique)
            {
                Thread.Sleep(200);
                num = rand.Next(10000, 100000).ToString();
                isUnique = CheckIsUniqueNum(num);
            }
            return num;
        }

        private static bool CheckIsUniqueNum(string num)
        {
            List<string> uniqueNums = StartApp.customers.Select(x => x.DigitAccountNumber.Substring(2,5)).ToList();
            return !uniqueNums.Contains(num);
        }

        public double InterestRate()
        {
            string str = DateTime.Now.ToString();
            double rate = double.Parse(str.Substring(str.Length - 5, 2))/25;

            return rate;
        }
    }
}