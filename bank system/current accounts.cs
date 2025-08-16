using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_system
{
    internal class current_accounts:Accounts
    {
        private decimal overdraft_limit;
        public decimal Limit
        {
            get { return overdraft_limit; }
            set
            {
                if (value >= 0)
                {
                    overdraft_limit = value;
                }
                else
                {
                    Console.WriteLine("overdraft limit must be greater than or equal 0");
                }
            }
        }
        public current_accounts(decimal bal,string type, decimal limit)
       : base(bal, type) 
        {
            Limit = limit;
        }

        public override void Displayaccinfo()
        {
            base.Displayaccinfo();
            Console.WriteLine($"Overdraft limit : {Limit}");
        }
    }
}
