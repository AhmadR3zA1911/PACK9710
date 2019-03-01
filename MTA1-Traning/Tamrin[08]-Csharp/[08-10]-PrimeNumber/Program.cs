using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_10__PrimeNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 0;
            bool prime = true;
            Console.Write("Please Enter Number > 1 :");
            number = int.Parse(Console.ReadLine());
            for (int i = 2; i < number ; i++)
            {
                if (number % i == 0)
                    prime = false;
            }

            if (number==1)
                Console.WriteLine("1 is neither a prime or a composite number.");
            else
            {
                if (prime)
                {
                    Console.WriteLine("{0} is Prime.",number);
                }
                else
                    Console.WriteLine($"{number} is not Prime.");
            }

            Console.ReadKey();
            
        }
    }
}
