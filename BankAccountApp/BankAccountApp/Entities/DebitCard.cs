using BankAccountApp.Interfaces;

namespace BankAccountApp.Entities
{
    internal class DebitCard : IHolder
    {
        public DebitCard(string debitCardNum,int pin)
        {
            // needed validation!
            this.DebitCardNum = debitCardNum;
            this.PIN = pin;
        }

        public string DebitCardNum { get; set; }
        public int PIN { get; set; }

        public void Info()
        {
            System.Console.WriteLine("\nDebit Card\nDebit Card Number: {0}\nPIN: {1}",this.DebitCardNum,this.PIN);
        }
    }
}