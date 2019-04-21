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
            string Orginal = "";
            string rivers = "";
            Console.Write("Please Enter String For Checking Palindrome:");
            Orginal = Console.ReadLine();

            for (int i = Orginal.Length-1 ; i >= 0 ; i--)
            {
                rivers += Orginal[i];
            }
            if (Orginal==rivers)
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
