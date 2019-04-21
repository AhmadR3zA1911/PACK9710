using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_06__CountTheFrequency
{
    class Program
    {
        static void Main(string[] args)
        {

            int indexCount = 0;
            int CountFr = 0;
            string[] Checkedstr;
            string[] str;
            Console.Write("Enter The Number Of Element To be Stored in The Array:");
            indexCount = Int32.Parse(Console.ReadLine());
            str = new string[indexCount];
            Checkedstr = new string[indexCount];
            for (int i = 0; i < indexCount; i++)
            {
                Console.Write($"Enter Element {i + 1}: ");
                str[i] = Console.ReadLine();
            }

            for (int k = 0; k < indexCount; k++)
            {
                CountFr = 0;
                if (Checkedstr[k] != "0")
                {
                    for (int x = 0; x < indexCount; x++)
                    {
                        if (str[k] == str[x])
                        {
                            CountFr++;
                            Checkedstr[x] = "0";

                        }
                    }

                    Console.WriteLine($"{str[k]} occurs {CountFr} times.");
                }

            }

            Console.ReadKey();
        }
    }
}
