using System;
using System.Text.RegularExpressions;

namespace Validation
{
    class Program
    {
        static void Main(string[] args)
        { 
            string[] str = { "9925612824", "8238783138", "02812451830"};

            foreach (string item in str)
            {
                Console.WriteLine("{0} {1} ett giltigt mobilnummer", item, IsValidTelephoneNumber(item) 
                    ? "är " : "är inte ");
            }
            /// xxx xxx xxx  ^[0-9]{10}$
            /// +xx xx  xxx xxx xx  ^+[0 - 9]{2}\s + [0 - 9]{2} \s+[0 - 9]{8}$

            /// xxx - xxxx -xxxx  ^+[0 - 9]{3} - [0 - 9]{4} - [0 - 9]{4}$
        }

        public static bool IsValidTelephoneNumber(string inputMobile)
        {
            string strRe = @"(^[0-9]{10}$)|(^\+[0-9]{2}\s+[0-9]{2}[0-9]{8}$|(^[0-9]{3}-[0-9]{4}-[0-9]{4}$)";

            Regex re = new Regex(strRe);

            if (re.IsMatch(inputMobile))
            {
                return true;
            }
            return false;
            
        }
    }
}
