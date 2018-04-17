namespace BankAccountApp
{
    using Interfaces;
    using Enums;
    using System;
    using BankAccountApp.Services;
    using BankAccountApp.Entities;

    public class CustomerAccount : ICustomerAccount
    {
        public CustomerAccount(string name, string socialSecurityNumber, string accountType, string initialDeposit)
        {
            this.Name = name;
            this.SocialSecurityNumber = socialSecurityNumber;
            this.InitialDeposit = decimal.Parse(initialDeposit);

            this.DigitAccountNumber = DigitAccountNumberGenerator();

            interestRateGenerator = new Generator();
            
            this.AccountType = (AccountType)int.Parse(accountType);
            if (this.AccountType == AccountType.Checking)
            {
                this.InterestRate = interestRateGenerator.InterestRate();
                this.Holder = new SafetyDepositBox(123,1234);
            }
            else
            {
                this.InterestRate = (interestRateGenerator.InterestRate() / 0.25);
                this.Holder = new DebitCard("QWERTY123ABC",1234);
            }
        }

        private Generator interestRateGenerator;

        public string Name { get; }
        public string SocialSecurityNumber { get; }
        public AccountType AccountType { get; }
        public decimal InitialDeposit { get; private set; }

        public string DigitAccountNumber { get; }
        public double InterestRate { get; }

        private string DigitAccountNumberGenerator()
        {
            string dan;

            if (AccountType.Checking == AccountType)
            {
                dan = "2";
            }
            else
            {
                dan = "1";
            }

            int ssnLength = SocialSecurityNumber.Length;
            dan += SocialSecurityNumber.Substring((ssnLength - 2), 2);

            dan += Generator.GenerateUniqueFiveDigit();

            Random rand = new Random();
            dan += rand.Next(100, 1000);

            return dan;
        }

        public void Deposit(decimal sum)
        {
            if (sum > 0)
            {
                this.InitialDeposit += sum;
                Console.WriteLine("Deposit went successfully!");
            }
            else
            {
                Console.WriteLine("Twere was a problem with deposit!");
            }
        }

        public string ShowInfo()
        {
            string separator =  "\nAccount Type: " + this.AccountType + "\nName: " + this.Name 
                + "\nSocial Security Number: " + this.SocialSecurityNumber + "\nInitialDeposit: " + this.InitialDeposit 
                + "\nDigit Account Number: " + this.DigitAccountNumber + "\n----------------------------"; 

            Holder.Info();
            return separator;
        }

        public void Transfer(CustomerAccount account, decimal sum)
        {
            try
            {
                if (sum > 0)
                {
                    account.Deposit(sum);
                    Console.WriteLine("Transfered {0}\nTo {1}", sum, account.ShowInfo());
                }
                else
                {
                    Console.WriteLine("You can't transfered {0} ", sum);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void Withdraw(decimal sum)
        {
            if (this.InitialDeposit - sum < 0)
            {
                Console.WriteLine("Initial Deposit is less than the sum you want to withdraw!");
            }
            else
            {
                this.InitialDeposit -= sum;
                Console.WriteLine(" -- Withdraw: {0}", sum);
            }
        }

        public IHolder Holder { get; }
    }
}