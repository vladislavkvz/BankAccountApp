namespace BankAccountApp
{
    using BankAccountApp.Services;
    using System;
    using System.Collections.Generic;

    public class StartApp
    {
        public static IList<CustomerAccount> customers = new List<CustomerAccount>();

        public static void Main()
        {   
            LoadCustomers();

            foreach (var customer in customers)
            {
                Console.WriteLine(customer.ShowInfo());
            }
        }

        private static void LoadCustomers()
        {
            string filePath = "Bank_Accounts.csv";
            CSVFileReader.ReadFromCSV(filePath, customers);
        }
    }
}