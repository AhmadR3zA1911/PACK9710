using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_05__DuplicateNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Num = new int[] { 1, 2,5,6,9 ,8,2,5,1 };
            int count = 0;
          

                for (int i = 0; i < Num.Length; i++)
                {
                
                    for (int j = i+1; j < Num.Length; j++)
                    {
                        if (Num[i] == Num[j])
                            count++;

                        if (count >= 1)
                        {
                            Console.WriteLine($"Total number of duplicate elements found in the array is :{Num[i]}");
                            count = 0;
                            break;
                        }
                        

                    }
                



                }
            
            Console.ReadKey();
        }
    }
}
