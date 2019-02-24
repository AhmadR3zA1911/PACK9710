using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_04__RemoveTheParentheses
{
    class Program
    {
        static string reverse_remove_parentheses(string str)
        {
            int CheckPar = str.LastIndexOf('(');
            if (CheckPar == -1)
            {
                return str;
            }
            else
            {
                int rid = str.IndexOf(')', CheckPar);

                return reverse_remove_parentheses(
                      str.Substring(0, CheckPar)
                    + new string(str.Substring(CheckPar + 1, rid - CheckPar - 1).Reverse().ToArray())
                    + str.Substring(rid + 1)
                );
            }
        }



        static void Main(string[] args)
        {
            Console.WriteLine(reverse_remove_parentheses("p(rq)st"));
            Console.WriteLine(reverse_remove_parentheses("(p(rq)st)"));
            Console.WriteLine(reverse_remove_parentheses("ab(cd(ef)gh)ij"));
            //string Text = "" ;
            //Console.Write("Please Enter String For Remove ->():");
            //Text = Console.ReadLine();
            //string NewText = "";
            //for (int i = 0; i < Text.Length; i++)
            //{
            //    if (Text[i]!='(' && Text[i] !=')')

            //    {
            //        NewText += Text[i];
            //    }
            //}
            //Console.WriteLine($"New Text Without ():{NewText}");


            Console.ReadKey();
        }
    }
}
