using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace bank_system
{
    public class Customers
    {
        public static int nextid = 1;
        private int Id;
        private string fullname;
        private string nationalId;
        private DateTime dateofbirth;
        private static List<Customers> customers = new List<Customers>();
        private List<Accounts> acc = new List<Accounts>();
        public int ID
        { get { return Id; }
            set { Id = value; }
        }
        public string Fullname
        {
            get { return fullname; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value)) {
                    Console.WriteLine("Name cannot be empty");
                }
                else
                {
                    fullname = value;
                }
            }
        }
        public string NationalId
        {
            get { return nationalId; }
            set {
                if (ulong.TryParse(value, out _) && value.Length == 14) 
                { nationalId = value; }
                else {
                    Console.WriteLine("National Id must be 14 number");
                }


            }
        }
        public DateTime DateofBirth
        {
            get { return dateofbirth; }
            set {
                int age = DateTime.Now.Year - value.Year;
                if (DateTime.Now.Month < value.Month || (DateTime.Now.Month == value.Month && DateTime.Now.Day < value.Day))
                {
                    age--;
                }

                if (age >= 18)
                {
                    dateofbirth = value;
                }
                else
                {
                    Console.WriteLine("Age must be greater than or equal 18");
                }

            }
        }
        public Customers(string name, string nationalid, DateTime date, decimal x, string type, decimal y)
        {
            Id = nextid++;
            Fullname = name;
            NationalId = nationalid;
            DateofBirth = date;
            customers.Add(this);
            AddAccount(x, type, y);
        }
        public void AddAccount(decimal x, string type, decimal y)
        {
            if (type.ToLower() == "saving")
            {
                acc.Add(new saving_accounts(x, type, y));
            }
            else {
                acc.Add(new current_accounts(x, type, y));
            }

        }
        // public void addnewcustomer(string name, string natid, DateTime date,decimal x,string type)
        //{
        //    Customers cust = new Customers(name,natid,date);
        //    customers.Add(cust);
        //    cust.AddAccount(x,type);
        //}

        public void updatename(string name)
        {
            Fullname = name;
            //bool x = false;
            //foreach (Customers cust in customers)
            //{
            //    if (cust.Id == id)
            //    {
            //        cust.Fullname = name;
            //        cust.DateofBirth = date;
            //        x = true;
            //    }
            //}
            //if (!x)
            //{
            //    Console.WriteLine("this customer isnot available");
            //}
        }

        public void updatedateofbirth(DateTime date)
        {
            DateofBirth = date;
        }

        public void UpdateDetails(string name, DateTime date)
        {
            Fullname = name;
            DateofBirth = date;
        }

        public decimal GetTotalBalance()
        {
            decimal total = 0;
            foreach (Accounts account in this.acc)
            {
                total += account.Balance;
            }
            return total;
        }
        public static void removecustbyid(int num)
        {
            foreach (Customers cust in customers.ToList())
            {
                if (cust.Id == num && cust.GetTotalBalance() == 0)
                {
                    customers.Remove(cust);
                    return;
                }
            }

            Console.WriteLine("this customer's balance is greater than 0 so it cannot be deleted");
        }
        public static void removeallcust()
        {
            foreach (Customers cust in customers.ToList())
            {
                if (cust.GetTotalBalance() == 0)
                {
                    customers.Remove(cust);
                }

            }

        }

        public void Displaycustinfo()
        {
            Console.WriteLine($"customer id : {Id}");
            Console.WriteLine($"customer FullName : {Fullname}");
            Console.WriteLine($"customer National Id : {NationalId}");
            Console.WriteLine($"Date of Birth {DateofBirth:dd/MM/yyyy}");
            Console.WriteLine($"No. Of Accounts :{this.acc.Count}");
            Console.WriteLine($"Accounts :");
            int i = 1;
            foreach (Accounts account in this.acc) {
                Console.WriteLine($"Account {i++}");
                account.Displayaccinfo();

            }
        }
        public static void Displaycustinfo(int id)
        {
            bool found = false;

            foreach (Customers cust in customers)
            {
                if (cust.Id == id)  
                {
                    Console.WriteLine($"Customer Id : {cust.Id}");
                    Console.WriteLine($"Customer FullName : {cust.Fullname}");
                    Console.WriteLine($"Customer National Id : {cust.NationalId}");
                    Console.WriteLine($"Date of Birth : {cust.DateofBirth:dd/MM/yyyy}");
                    Console.WriteLine($"No. Of Accounts : {cust.acc.Count}");
                    Console.WriteLine("Accounts :");

                    int i = 1;
                    foreach (Accounts account in cust.acc)
                    {
                        Console.WriteLine($"Account {i++}:");
                        account.Displayaccinfo();
                    }

                    found = true;
                    break; 
                }
            }

            if (!found)
            {
                Console.WriteLine("This customer is not available");
            }
        }

        public static void searchbynameornatid(int id)
        {

            foreach (Customers cust in customers)
            {
                if (cust.Id == id)
                {
                    cust.Displaycustinfo();
                    return;

                }
            }
            Console.WriteLine("this customer isnot available");
        }
        public static void searchbynameornatid(string natid)
        {
            foreach (Customers cust in customers)
            {
                if (cust.NationalId == natid)
                {
                    cust.Displaycustinfo();
                    return;
                }

            }


            Console.WriteLine("this customer isnot available");

        }

        public static void displayallinfo()
        {
            foreach (Customers cust in customers) {
                cust.Displaycustinfo();
                Console.WriteLine("---------------------------------------");
            }
        }



    }

}
    

