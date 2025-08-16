using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_system
{
    public class Transaction
    {
        private DateTime date;
        private string type;
        public decimal amount;
        private decimal balanceAfter;
        private string note;
        public int accnum;
        public DateTime Date { get { return date; }
            set {
                date = value;
            }
            }
        public string Type {
        get { return type; }
            set {type = value; }
        }  
        public decimal Amount {
        get { return amount; }
            set { amount = value; }
        }
        public decimal BalanceAfter { 
            get { return balanceAfter; }
        set { balanceAfter = value; }
        }
        public string Note { 
        get { return note; }
        set { note = value; }
        }   

        public Transaction(string type, decimal amount, decimal balanceAfter, int num,string note = "")
        {
            Date = DateTime.Now;
            Type = type;
            Amount = amount;
            BalanceAfter = balanceAfter;
            Note = note;
            accnum = num;
        }

        public void DisplayTransaction()
        {
            Console.WriteLine($"Date : {Date:dd/MM/yyyy}");
            Console.WriteLine($"Type : {Type}");
            Console.WriteLine($"Amout of money :{Amount}");
            Console.WriteLine($"Balance After :{BalanceAfter}");
            Console.WriteLine($"Notes :{Note}");
           
        }
    }

}
