using System;
using System.CodeDom;
using System.Configuration;
using System.Data.Common;
using System.Management.Instrumentation;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Threading;

namespace SimpleLibrary
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Header(); // Load Header :D 
            MenuList();
            Book[] BookInfo = new Book[] { new Book(-99, "temp", "777", "temp", 2019, "Temp") }; //First Book is Temp
            //Book[] BookInfo = new Book[] { new Book() };
            var select = Console.ReadLine();

            for (; true;) // Infinity Loop For Menu 
            {
                if (select == "1") //Show All Book
                {
                    
                    if (BookInfo.Length > 1)
                    {

                        ShowAllBook(ref BookInfo);
                        Console.WriteLine("\nPress Any Key Load Menu ....");
                        Console.ReadKey();
                        MenuList();
                    }
                    else
                    {
                        Console.WriteLine("Your List Is Empty , Add a book");
                        Console.ReadKey();
                        Console.Clear();
                        MenuList();
                    }
                }
                else if (select == "2") // Edit Exist Book
                {
                    if (BookInfo.Length > 1)
                        EditBookList(ref BookInfo);
                    else
                    {

                        Console.WriteLine("Your List Is Empty , Add a book");
                        Console.ReadKey();
                        Console.Clear();
                        MenuList();
                    }
                }
                else if (select == "3") // Add New Book
                {
                    AddToBook(ref BookInfo);
                }
                else if (select == "4") // Remove Book From List
                {
                    if (BookInfo.Length > 1)
                        RemoveFromList(ref BookInfo);
                    else
                    {
                        Console.WriteLine("Your List Is Empty , Add a book");
                        Console.ReadKey();
                        Console.Clear();
                        MenuList();
                    }
                }
                else if (select == "5") // Exit
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;

                    Console.WriteLine("AhmadR3zA - 1397/12/12 | Press Any Key To Exit ; )");
                    Console.ResetColor();

                    break;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;

                    Console.WriteLine("Invalid Number Enter For Countinue...");
                    Console.ResetColor();
                    Console.Beep(2000, 100);
                    Console.Beep(2000, 200);
                    Console.ReadKey();
                    MenuList();
                }

                select = Console.ReadLine();
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Show ASCCI Welcome
        /// </summary>
        static void Header()
        {
            Console.Title = "Welcome To Book Manager";
            //string[] color = new string[] { "Blue", "Green", "Yellow", "Gray", "blue", "White", "Gray" };
            string[] h = new string[7];
            h[0] = @"|\     /|(  ____ \( \      ( \      (  ____ \(  ___  )(       )(  ____ \";
            h[1] = @"| )   ( || (    \/| (      | (      | (    \/| (   ) || () () || (    \/";
            h[2] = @"| | _ | || (__    | |      | |      | |      | |   | || || || || (__    ";
            h[3] = @"| |( )| ||  __)   | |      | |      | |      | |   | || |(_)| ||  __)   ";
            h[4] = @"| || || || (      | |      | |      | |      | |   | || |   | || (      ";
            h[5] = @"| () () || (____/\| (____/\| (____/\| (____/\| (___) || )   ( || (____/\";
            h[6] = @"(_______)(_______/(_______/(_______/(_______/(_______)|/     \|(_______/";

            for (int i = 0; i < h.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(h[i]);
                Thread.Sleep(100);
                Console.Beep(800, 500);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\nPress any Key To view Menu...");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
        } // end header 

        /// <summary>
        /// Main Menu
        /// </summary>
        static void MenuList()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n/////////////////////////////////////////////////////");
            Console.WriteLine("1.Show All Book.");
            Console.WriteLine("2.Edit Book.");
            Console.WriteLine("3.Add New Book.");
            Console.WriteLine("4.Remove a book.");
            Console.WriteLine("5.Exit.");
            Console.WriteLine("/////////////////////////////////////////////////////");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Enter Your Choice:");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void AddToBook(ref Book[] b)
        {
            int Id = 0;

            string Name = "";
            string ISBN = "";
            string Author = "";
            //DateTime Year = DateTime.Now;
            int Year = 2019;
            string Publisher = "";
            Book[] newbook = new Book[b.Length + 1];
            Console.Clear();

            Console.Write("\nPlease Enter ID Number:");
            Id = int.Parse(Console.ReadLine());
            Console.Write("\nPlease Enter Book Name:");
            Name = Console.ReadLine();
            Console.Write("\nPlease Enter ISNB:");
            ISBN = Console.ReadLine();
            Console.Write("\nPlease Enter Author:");
            Author = Console.ReadLine();
            Console.Write("\nPlease Enter Year:");
            // Year = Convert.ToDateTime(Console.ReadLine());
            Year = int.Parse(Console.ReadLine());
            Console.Write("\nPlease Enter Publisher:");
            Publisher = Console.ReadLine();
            for (int i = 0; i < b.Length; i++)
            {

                newbook[i] = b[i];

            }

            newbook[newbook.Length - 1] = new Book(Id, Name, ISBN, Author, Year, Publisher);
            b = newbook;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPress Any Key Save The INFO");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
            MenuList();


            // books[0]=new Book(Id, Name, ISBN, Author, Year, Publisher);
        }

        static void ShowAllBook(ref Book[] b)
        {
            Console.Clear();
            for (int i = 1; i < b.Length; i++)
            {
                Console.WriteLine(b[i]);
            }


        }

        static void RemoveFromList(ref Book[] b)
        {
            Console.Write("Enter Book Id For Remove:");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Book ISBN For Remove:");
            string ISBN = Console.ReadLine();
            Book[] newbook = new Book[b.Length - 1];

            int Count = 0;

            foreach (Book item in b)
            {
                if (item.Id == id && item.ISBN == ISBN)
                    Count++;
            }

            if (Count != 0)
            {
                for (int i = 0; i < b.Length; i++)
                {
                    if (b[i].Id != id && b[i].ISBN != ISBN)
                        newbook[i] = b[i];
                }


                b = newbook;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"The Book with ID:{id} And ISBN:{ISBN} Removed Successful");

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Id Number and ISBN The book Not Exist, Try Another One, press any key for menu...");
            }

            Count = 0;

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nPress Any Key Load Menu....");
            Console.ReadKey();
            Console.Clear();
            MenuList();
        }


        static void EditBookList(ref Book[] b)
        {
            ShowAllBook(ref b);
            Book[] newbook = new Book[b.Length];
            Console.Write("Enter Book Id For Remove:");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Book ISBN For Remove:");
            string isbn = Console.ReadLine();
            int Count = 0;
            //////////////
            int newId = 0;
            string newName = "";
            string newISBN = "";
            string newAuthor = "";
            //DateTime Year = DateTime.Now;
            int newYear = 2019;
            string newPublisher = "";
            /////////
            foreach (Book item in b)
            {
                if (id == item.Id && isbn == item.ISBN)
                {
                    Count++;
                }
            }

            if (Count > 0)
            {
                Console.Write("\nPlease Enter NEW ID Number:");
                newId = int.Parse(Console.ReadLine());
                Console.Write("\nPlease Enter NEW NAME Number:");
                newName = Console.ReadLine();

                Console.Write("\nPlease Enter NEW ISNB:");
                newISBN = Console.ReadLine();
                Console.Write("\nPlease Enter NEW Author:");
                newAuthor = Console.ReadLine();
                Console.Write("\nPlease Enter NEW Year:");
                // Year = Convert.ToDateTime(Console.ReadLine());
                newYear = int.Parse(Console.ReadLine());
                Console.Write("\nPlease Enter NEW Publisher:");
                newPublisher = Console.ReadLine();

                for (int i = 1; i < b.Length; i++)
                {
                    if (b[i].Id == id && b[i].ISBN == isbn)
                    {
                        b[i].Id = newId;
                        b[i].Name = newName;
                        b[i].ISBN = newISBN;
                        b[i].Year = newYear;
                        b[i].Author = newAuthor;
                        b[i].Publisher = newPublisher;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"The Book with ID:{id} And ISBN:{isbn} Edited Successful");
                        break;
                    }
                }
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Id Number and ISBN The book Not Exist, Try Another One, press any key for menu...");

            }
            Count = 0;

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nPress Any Key Load Menu....");
            Console.ReadKey();
            Console.Clear();
            MenuList();
        }
    }
}


/*
تمرین [09]
برنامه‌ای بنویسید که
یک header خوش‌آمد گویی داشته باشد
و لیستی با مضمون
1-show all books
2-edit book
3-add book
4-delete book
5-exit

در صفحه add
لیستی با مضمون
1-add
2-name
3-isbn
4-author
5-year
6-publisher

در صفحه edit
ابتدا لیست کتاب ها نمایش داده بشود
و سپس اطلاعات edit درخواست بشود

در پایان هر مرحله به منوی اصلی بازگردد
ویرایش: با class نوشته شود
*/

/*

            @"

|\     /|(  ____ \( \      ( \      (  ____ \(  ___  )(       )(  ____ \
| )   ( || (    \/| (      | (      | (    \/| (   ) || () () || (    \/
| | _ | || (__    | |      | |      | |      | |   | || || || || (__    
| |( )| ||  __)   | |      | |      | |      | |   | || |(_)| ||  __)   
| || || || (      | |      | |      | |      | |   | || |   | || (      
| () () || (____/\| (____/\| (____/\| (____/\| (___) || )   ( || (____/\
(_______)(_______/(_______/(_______/(_______/(_______)|/     \|(_______/

                        ";
*/
