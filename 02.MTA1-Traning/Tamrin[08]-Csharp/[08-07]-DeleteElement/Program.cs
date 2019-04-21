using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_07__DeleteElement
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] str;
            string[] strnew;
            int indexCount = 0;
            Console.WriteLine("Enter The Number Of Element To be Stored in The Array");
            indexCount = Int32.Parse(Console.ReadLine());
            str = new string[indexCount];
            strnew = new string[indexCount];
            for (int i = 0; i < indexCount; i++)
            {
                Console.Write($"Enter Element {i + 1}: ");
                str[i] = Console.ReadLine();
            }
            Console.Write("Input the position where to delete:");
            string rem = Console.ReadLine();
            for (int i = 0; i < indexCount; i++)
            {
                if (str[i] != rem)
                    strnew[i] = str[i];
            }
            Console.Write("The new list is:");
            for (int i = 0; i < strnew.Length; i++)
            {
                Console.Write(strnew[i]);
            }
            Console.ReadKey();
        }
    }
}
