using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_01__CheckString
{
    class Program
    {
        static void Main(string[] args)
        {
            string Orginal = "palindrome";
            Console.Write("Please Enter String For check:");
            if (Orginal==Console.ReadLine())
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }

            Console.ReadKey();
        }
    }
}
