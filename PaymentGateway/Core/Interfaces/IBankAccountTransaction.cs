using PaymentGateway.Core.Models;
namespace PaymentGateway.Core.Interfaces
{
    public interface IBankAccountTransaction
    {
        public bool deposit(User user, BankAccount account);

        public bool withdraw(User user, BankAccount account);

        public bool transafer(User user, BankAccount account);

        public bool printStatement(User user, BankAccount account);
    }
}
