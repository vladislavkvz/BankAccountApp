namespace BankAccountApp.Interfaces
{
    interface ICustomerAccount
    {
        void Deposit(decimal sum);
        void Withdraw(decimal sum);
        void Transfer(CustomerAccount account, decimal sum);
        string ShowInfo();
    }
}