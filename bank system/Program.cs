using System.Xml.Linq;

namespace bank_system
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome");
            Customers c1 = new Customers("doha", "12345123451234", new DateTime(2004, 6, 1), 200000, "saving", 10);
            Customers c2 = new Customers("Habiba", "12345678912345", new DateTime(2004, 6, 1), 100000, "current", 500);
            Console.WriteLine("Enter bank Name ");
            string x = Console.ReadLine();
            Console.WriteLine("Enter bank code ");
            int y =Convert.ToInt32( Console.ReadLine());
            Bank _bank =new Bank(x, y);
            _bank.DisplayBankInfo();
            int c = 0;
            while (c != 10)
            {
                Console.WriteLine("to add new usr press 1 , 2 to display all users info ," +
                    "3 to search for user by id or national id ,4 to display a user info ," +
                    "5 if you want to delete all 0 balance users ," +
                    "6 to delete a certain user , 7 to deposit , 8 to withdraw , 9 to transfere,10 to exit");
                 c = Convert.ToInt32(Console.ReadLine());
                if (c == 1)
                {
                    Console.WriteLine("Enter Full Name ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter National Id ");
                    string nat = Console.ReadLine();
                    Console.WriteLine("Enter Date of birth");
                    DateTime birth = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Enter Account type saving or current");
                    string type = Console.ReadLine();
                    Console.WriteLine("Enter balance");
                    decimal bal = Convert.ToDecimal(Console.ReadLine());
                    if (type.ToLower() == "saving")
                    {
                        Console.WriteLine("Enter Interest rate");
                    }
                    else if (type.ToLower() == "current")
                    {
                        Console.WriteLine("Enter Overdraft limit");
                    }
                    decimal yy = Convert.ToDecimal(Console.ReadLine());
                    Customers c3 = new Customers(name, nat, birth, bal, type, yy);
                    Console.WriteLine("Customer Added Successfully");
                    c3.Displaycustinfo();
                    int j = 0;
                    Console.WriteLine("if you want to add a new account to this cust press 1 else press any thing");
                    j = Convert.ToInt32(Console.ReadLine());
                    if (j == 1)
                    {
                        Console.WriteLine("Enter Account type saving or current");
                        string typ = Console.ReadLine();
                        Console.WriteLine("Enter balance");
                        decimal ba = Convert.ToDecimal(Console.ReadLine());
                        if (type.ToLower() == "saving")
                        {
                            Console.WriteLine("Enter Interest rate");
                        }
                        else if (type.ToLower() == "current")
                        {
                            Console.WriteLine("Enter Overdraft limit");
                        }
                        decimal yyy = Convert.ToDecimal(Console.ReadLine());
                        c3.AddAccount(ba, typ, yyy);
                    }
                    Console.WriteLine("total balance this customer has is");
                    c3.GetTotalBalance();
                    Console.WriteLine("To change name press 3");
                    j = Convert.ToInt32(Console.ReadLine());
                    if (j == 3)
                    {
                        Console.WriteLine("Enter new name");
                        string d = Console.ReadLine();
                        c3.updatename(d);
                    }



                }
                
                else if (c == 2)
                {
                    Customers.displayallinfo();
                }
                else if (c == 3)
                {
                    Console.WriteLine("Enter what you want to search by Id or national Id");
                    var z = Console.ReadLine();


                    if (int.TryParse(z, out int id))
                    {

                        Customers.searchbynameornatid(id);
                    }
                    else
                    {

                        Customers.searchbynameornatid(z);
                    }
                }
                else if (c == 4)
                {
                    Console.WriteLine("enter user Id");
                    int o = Convert.ToInt32(Console.ReadLine());
                    Customers.Displaycustinfo(o);
                }
                else if (c == 5)
                {
                    Customers.removeallcust();
                }
                else if (c == 6)
                {
                    Console.WriteLine("enter user's id");
                    int g = Convert.ToInt32(Console.ReadLine());
                    Customers.removecustbyid(g);
                }

                else if (c == 7) 
                {
                    Console.WriteLine("Enter Account Number:");
                    int accnum = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter amount to deposit:");
                    decimal amount = Convert.ToDecimal(Console.ReadLine());

                    bool found = false;
                    foreach (Accounts acc in Accounts.accounts)  
                    {
                        if (acc.Accountnum == accnum)
                        {
                            acc.Deposit(amount);  
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                        Console.WriteLine("Account not found.");
                }
                else if (c == 8) 
                {
                    Console.WriteLine("Enter Account Number:");
                    int accnum = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter amount to withdraw:");
                    decimal amount = Convert.ToDecimal(Console.ReadLine());

                    bool found = false;
                    foreach (Accounts acc in Accounts.accounts) 
                    {
                        if (acc.Accountnum == accnum)
                        {
                            acc.withdraw(amount); 
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                        Console.WriteLine("Account not found.");
                }

                else if (c == 9) 
                {
                    Console.WriteLine("Enter Source Account Number:");
                    int srcAcc = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Target Account Number:");
                    int tgtAcc = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter amount to transfer:");
                    decimal amount = Convert.ToDecimal(Console.ReadLine());

                    Accounts source = null;
                    Accounts target = null;

                   
                    foreach (Accounts acc in Accounts.accounts)
                    {
                        if (acc.Accountnum == srcAcc) source = acc;
                        if (acc.Accountnum == tgtAcc) target = acc;
                    }

                    if (source != null && target != null)
                    {
                        source.transfere(tgtAcc, amount); 
                    }
                    else
                    {
                        Console.WriteLine("Source or Target account not found.");
                    }
                }
                else if (c == 10)
                {
                    Console.WriteLine("Thank you for using our bank");
                }
                else
                {
                    Console.WriteLine("Not Available option");

                }
            }
            
        }
    }
}
