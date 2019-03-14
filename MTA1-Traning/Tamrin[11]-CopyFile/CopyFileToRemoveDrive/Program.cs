using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyFileToRemoveDrive
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Select Option number:");
            MenuList();
            for (;;)
            {
                

                Console.ReadLine();
            }

        }



        /// <summary>
        /// Main Menu
        /// </summary>
        static void MenuList()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\n_______________--------------------_______________");
            Console.WriteLine("1.Copy This Session.");
            Console.WriteLine("2.Select Source Folder.");
            Console.WriteLine("3.Add New Book.");
            Console.WriteLine("/--------------------_______________--------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Enter Your Choice:");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

    }
}
