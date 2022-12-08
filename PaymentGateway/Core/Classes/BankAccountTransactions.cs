using PaymentGateway.Core.DataContext;
using PaymentGateway.Core.Interfaces;
using PaymentGateway.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Core.Classes
{
    public class BankAccountTransactions : IBankAccountTransaction
    {
        private readonly PaymentGatewayContext _context;

        public BankAccountTransactions(PaymentGatewayContext context)
        {
            _context = context;
        }

        public bool deposit(User user, BankAccount account)
        {
            int depositeMoney = 0;
            Console.WriteLine("Your Balance: " + account.BalanceAmount);
            Console.WriteLine("Enter Deposite Amount");
            depositeMoney = Convert.ToInt32(Console.ReadLine());
            BankAccount bankAccount = _context.BankAccount.Where(x => x.AccountId == account.AccountId).FirstOrDefault();
            bankAccount.BalanceAmount = bankAccount.BalanceAmount + depositeMoney;

            BankStatement bankStatement = new BankStatement() { AccountId = account.AccountId, CreditAmount = depositeMoney, DebitAmount = 0, TransactionTime = DateTime.Now };
            _context.bankStatements.Add(bankStatement);
            _context.SaveChanges();
            Console.WriteLine("Your Current Balance:" + account.BalanceAmount);
            Console.ReadKey();
            return true;    
        }

        public bool transafer(User user, BankAccount account)
        {
            int transferMoney = 0;
            int transferAccountId = 0; 
            Console.WriteLine("Your Balance: " + account.BalanceAmount);
            Console.WriteLine("Enter Transfered Amount:");
            transferMoney = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Transfered Account Id :");
            transferAccountId = Convert.ToInt32(Console.ReadLine());

            if(transferMoney != 0 && transferAccountId != 0){
                BankAccount bankAccount = _context.BankAccount.Where(x => x.AccountId == account.AccountId).FirstOrDefault();
                BankAccount transferBankAccount = _context.BankAccount.Where(x => x.AccountId == transferAccountId).FirstOrDefault();

                if (transferBankAccount == null) {
                    Console.WriteLine("Account Id not found");
                    Console.ReadKey();
                    return false;   
                }

                bankAccount.BalanceAmount = bankAccount.BalanceAmount - transferMoney;
                transferBankAccount.BalanceAmount = transferBankAccount.BalanceAmount + transferMoney;

                BankStatement bankStatement = new BankStatement() { AccountId = bankAccount.AccountId, CreditAmount = 0, DebitAmount = transferMoney, TransactionTime = DateTime.Now };
                BankStatement transferbankStatement = new BankStatement() { AccountId = transferBankAccount.AccountId, CreditAmount = transferMoney, DebitAmount = 0, TransactionTime = DateTime.Now };
                _context.bankStatements.Add(bankStatement); 
                _context.bankStatements.Add(transferbankStatement);
                _context.SaveChanges();
                Console.WriteLine("Your Current Balance:" + account.BalanceAmount);
                Console.ReadKey();
                return true;
            }

            return false;
        }

        public bool withdraw(User user, BankAccount account)
        {
            int withdrawMoney = 0;
            Console.WriteLine("Your Balance: " + account.BalanceAmount);
            Console.WriteLine("Enter Withdraw Amount");
            withdrawMoney = Convert.ToInt32(Console.ReadLine());
            BankAccount bankAccount = _context.BankAccount.Where(x => x.AccountId == account.AccountId).FirstOrDefault();

            if (withdrawMoney > bankAccount.BalanceAmount) {
                Console.WriteLine("No sufficient Balance in your bank amount");
                Console.ReadKey(); 
                return false;
            }

            bankAccount.BalanceAmount = bankAccount.BalanceAmount - withdrawMoney;
            BankStatement bankStatement = new BankStatement() { AccountId = account.AccountId, CreditAmount = 0, DebitAmount = withdrawMoney, TransactionTime = DateTime.Now };
            _context.bankStatements.Add(bankStatement);
            _context.SaveChanges();
            Console.WriteLine("Your Current Balance:" + account.BalanceAmount);
            Console.ReadKey();
            return true;
        }

        public bool printStatement(User user, BankAccount account)
        {
            Console.WriteLine("*********************** Account Statement ****************** AccountId: " + account.AccountId + " ***********************");
            List<BankStatement> bankStatements = _context.bankStatements.Where(x => x.AccountId == account.AccountId).ToList();
            Console.WriteLine("Account Id\t\tCreditAmount\t\tDebitAmount\t\tTransactionTime");
            foreach (BankStatement bankStatement in bankStatements)
            {
                Console.WriteLine(bankStatement.AccountId + "\t\t\t" + bankStatement.CreditAmount + "\t\t\t" + bankStatement.DebitAmount + "\t\t\t" + bankStatement.TransactionTime.ToShortDateString());
            }
            Console.WriteLine("Total Account Balance : " + account.BalanceAmount);
            Console.ReadKey();
            return true;
        }
    }
}
