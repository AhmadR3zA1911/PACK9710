using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordGeneratorWithChoice
{
    class Program
    {
        [STAThread] //For use Clipboard
        static void Main(string[] args)
        {
            int PasswordLen = 0;
            Console.Write("Please Enter Password Length:");

            PasswordLen = Convert.ToInt32(Console.ReadLine());

            if (PasswordLen<=0)
            {
                Console.WriteLine("Please Enter Number greater Than \'0\'");
                
            }
            else
            {
                int Choice=-1;
                int rand = 0;
                Console.Clear(); // Cleac Screen
                Console.WriteLine("Please Choose Your Password Compelextly\n**********************");
                Console.WriteLine("1:Only Aplhabet\n=============\n2.Alphabet + Number\n=============\n3.All Character\n=============\n");
                Console.Write("Enter Title Number:");
                Choice = Convert.ToInt16(Console.ReadLine());
                string PassText = "";
                if (Choice == 1)
                {
                    Random r = new Random();

                    for (int i = 0; i < PasswordLen; i++)
                    {
                        rand = r.Next(0, 2);
                        if (rand == 0)
                        {
                            PassText += Convert.ToChar(r.Next(65, 91)); //65=A / 90=Z 
                        }
                        else
                        {
                            PassText += Convert.ToChar(r.Next(97, 123)); //97=A / 122=Z 
                        }
                    }
                }
                else if (Choice == 2)
                {
                    Random r = new Random();

                    for (int i = 0; i < PasswordLen; i++)
                    {
                        rand = r.Next(0, 3);
                        if (rand == 0)
                        {
                            PassText += Convert.ToChar(r.Next(65, 91));
                        }
                        else if (rand == 1)
                        {
                            PassText += Convert.ToChar(r.Next(97, 123));
                        }
                        else
                        {
                            PassText += r.Next(0, 10);
                        }
                    }

                }

                else if (Choice == 3)
                {

                    Random r = new Random();

                    for (int i = 0; i < PasswordLen; i++)
                    {
                        PassText += Convert.ToChar(r.Next(32, 122));

                    }
                }

                else
                {
                    Console.WriteLine("Wrong input Please Try Again!");

                }

                Console.WriteLine($"Your Pass is:{PassText}");
                Clipboard.SetText(PassText);
                Console.WriteLine("\n****The Password copied in your clipboard.****");

                
            }
            Console.ReadKey();
        }
    }
}
