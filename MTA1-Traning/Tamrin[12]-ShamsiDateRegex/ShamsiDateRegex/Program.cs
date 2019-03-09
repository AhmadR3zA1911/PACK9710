using System;
using System.Text.RegularExpressions;

namespace ShamsiDateRegex
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Regex r = new Regex(@"([12]\d{3}\/((0[1-6])\/(0[1-9]|[12]\d|3[01])|((0[7-9]|1[0-2])\/(0[1-9]|[12]\d|3[0]))))|([12]\d{3}-((0[1-6])-(0[1-9]|[12]\d|3[01])|((0[7-9]|1[0-2])-(0[1-9]|[12]\d|3[0]))))");

            for (;;)
            {
                Console.Write("Date (1397/01/01 || 1397-12-30):");
                var text = Console.ReadLine();
                if (text=="exit")
                    break;
                var isMatch = r.IsMatch(text);
                if (isMatch)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Match!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not Match!");
                }
                
                Console.ResetColor();
            }
        }
    }
}