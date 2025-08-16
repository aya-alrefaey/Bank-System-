using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_system
{
    internal class saving_accounts:Accounts
    {
        private decimal interest_rate;
        public decimal Irate { 
        get {return interest_rate;}
            set
            {
                if (value >= 0)
                {
                    interest_rate = value;
                }
                else
                {
                    Console.WriteLine("Interest rate must be greater than or equal zero");
                }
            }
        }
        public saving_accounts(decimal bal, string type, decimal rate)
       : base(bal, type)
        {
            Irate = rate;
        }

        public override void Displayaccinfo()
        {
            base.Displayaccinfo();
            Console.WriteLine($"Interest Rate : {interest_rate}%");
        }

        public decimal CalculateMonthlyInterest()
        {
            return Balance * (interest_rate / 12);
        }

        public void ApplyMonthlyInterest()
        {
            decimal interest = CalculateMonthlyInterest();
            Balance += interest;
            Console.WriteLine($"Monthly interest {interest} added. New Balance = {Balance}");
        }


    }
}
