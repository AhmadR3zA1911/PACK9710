using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_08_ReverseOrderOfTheWord
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
            for (int i = TextArr.Length-1 ; i >=0 ; i--)
            {
                RevText += TextArr[i];
                if (i!=0) // اضافه نکردن فاصله اضافی در آخر رشته
                RevText += " ";
            }
            Console.Write("Reverse Sentence :{0}", RevText);
            Console.ReadKey();
        }
    }
}
