using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace bank_system
{
    public class Accounts
    {
        private static int nextaccid = 0;
        private int account_number;
        private decimal balance;
        private DateTime dateopened;
        public static List<Accounts> accounts = new List<Accounts>();
        private string account_type;
        private List<Transaction> transaction = new List<Transaction>();
        public int Accountnum {
            get { return account_number; } 
        }
        public DateTime Dateopened
        {
            get { return dateopened; }
            set { dateopened = value; }
        }
        public string Account_Type
        {
            get { return account_type; }
            set {
            if (value.ToLower()!="saving"&& value.ToLower()!= "current")
                {
                    Console.WriteLine("There are only two types of accounts Saving & Current");
                }
                else
                {
                    account_type = value;
                }
            }
        }
        public decimal Balance
        {
            get { return balance; }
            set {
                if (balance >= 0) {
                    balance = value;
                }
                else
                    Console.WriteLine("balance must be greater than or equal zero");
                 }
           
          
        }
        public Accounts(decimal bal,string type)
        {
            account_number = nextaccid++;
            Balance = bal;
            dateopened = DateTime.Now;
            accounts.Add(this);
            Account_Type = type;
            accounts.Add(this);
        }
        public virtual void Displayaccinfo()
        {
            Console.WriteLine($"Account number : {Accountnum}");
            Console.WriteLine($"Date Opened : {Dateopened}");
            Console.WriteLine($"Acount Type : {Account_Type}");
            Console.WriteLine($"Balance : {Balance}");
        }
        public void Deposit(decimal m)
        {
            if (m >= 0)
            {
                Balance += m;
                transaction.Add(new Transaction("deposit",m, this.Balance,this.Accountnum));
            }
          
        }
        public void Deposit(int accnum, decimal m)
        {
            bool found = false;

            foreach (Accounts acc in accounts)
            {
                if (acc.Accountnum == accnum&& m >= 0) 
                {
                    acc.Deposit(m);       
                    found = true;
                    transaction.Add(new Transaction("deposit", m, acc.Balance, this.Accountnum));
                    break;                     
                }
            }

            if (!found)
            {
                Console.WriteLine($"Account {accnum} not found for this customer.");
            }
        }

        public void withdraw(decimal m)
        {
            if (m > Balance)
            {
                Console.WriteLine("your balance is not enough");
            }
           
            else if(m>0)
            {
                Balance -= m;
                transaction.Add(new Transaction("withdraw", m, this.Balance, this.Accountnum));
            }
            else
            {
                Console.WriteLine("amount must be greater than 0 ");
            }

        }
        public void transfere(int accnum,decimal money)
        {
            if (money <= 0)
            {
                Console.WriteLine("Amount must be greater than 0");
                return;
            }

            Accounts target = null;
            foreach (Accounts acc in accounts) {
            if(acc.Accountnum == accnum)
                {
                    target = acc;
                    break;

                }
            }
            if (target == null)
            {
                Console.WriteLine("Target account not found");
                return;
            }
            if (this.Balance >= money)
            {
                this.withdraw(money);
                target.Deposit(money);
                Console.WriteLine($"Transferred {money} to account {accnum}");
                transaction.Add(new Transaction("transfere", money, this.Balance,this.Accountnum,$"to account :{accnum}"));
            }
            else
            {
                Console.WriteLine("Insufficient balance");
            }
        }


    }
}
