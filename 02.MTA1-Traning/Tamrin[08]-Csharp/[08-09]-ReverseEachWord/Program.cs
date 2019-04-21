using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_09__ReverseEachWord
{
    class Program
    {
        static void Main(string[] args)
        {
            string Text = "";
            string RevText = "";
            Console.Write("Enter Your Sentence:");
            Text = Console.ReadLine();
            string[] TextArr = Text.Split(' ');
            for (int i = 0; i < TextArr.Length ; i++)
            {
                Text = TextArr[i];
                for (int j = Text.Length - 1; j >= 0; j--)
                {
                    RevText += Text[j];
                }
                if (i != TextArr.Length-1) // اضافه نکردن فاصله اضافی در آخر رشته
                    RevText += " ";
            }

            Console.Write("Reverse Sentence :{0}", RevText);
            Console.ReadKey();
        }


    }
}

