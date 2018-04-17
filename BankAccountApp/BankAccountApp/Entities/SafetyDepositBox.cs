using BankAccountApp.Interfaces;

namespace BankAccountApp.Entities
{
    internal class SafetyDepositBox : IHolder
    {
        public SafetyDepositBox(int identifyNum,int code)
        {
            // needed validation!
            this.IdentifiedNum = identifyNum;
            this.Code = code;
        }

        public int IdentifiedNum { get; set; }
        public int Code { get; set; }

        public void Info()
        {
            System.Console.WriteLine("\nSafety Deposit Box\nIdentify Number: {0}\nCode: {1}", this.IdentifiedNum, this.Code);
        }
    }
}