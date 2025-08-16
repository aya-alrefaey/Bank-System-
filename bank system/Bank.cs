using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace bank_system
{
    // next session => collections
    internal class Bank
    {
        private readonly string bank_name;
        private readonly int bank_code;
        public string Name {
            get 
            { return bank_name; } 
        }
        public int Num {
            get {  return bank_code; }   
        }
        public Bank(string name, int code)
        {
            bank_name = name;
            bank_code = code;
        }
        public void DisplayBankInfo()
        {
            Console.WriteLine($"Bank name is {bank_name}");
            Console.WriteLine($"Bank code is {bank_code}");
        }
        
    }

    

   

}
