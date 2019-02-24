using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_04__RemoveTheParentheses
{
    class Program
    {
 


        static void Main(string[] args)
        {

            string Text = "";
            string Temp = "";
            Console.Write("Please Enter String For Remove ->():");
            Text = Console.ReadLine();
            string NewText = "";
            for (int i = 0; i < Text.Length; i++)
            {
                if (Text[i] != '(' && Text[i] != ')')

                {
                    NewText += Text[i];
                }
                else if (Text[i] == '(')
                {
                    while (Text[i] != ')')
                    {
                        if (Text[i] != '(' && Text[i] != ')')

                            Temp += Text[i++];
                        else
                            i++;
                    }
                    NewText += new string(Temp.Reverse().ToArray()); //reverse
            
                    Temp = "";
                }
            }
            Console.WriteLine($"New Text Without ():{NewText}");


            Console.ReadKey();
        }
    }
}
