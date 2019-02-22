using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_3__SurfaceVolumeOfSphere
{
    class Program
    {
        static void Main(string[] args)
        {
            double Rad = 0;
            double Volume;
            double sourface;
            Console.WriteLine("Please Enter The Radius:");
            Rad = Convert.ToDouble(Console.ReadLine());
            Volume = ((4 / 3) * 3.142857 )* (Rad * Rad * Rad);
            sourface = (4 * 3.142857) * (Rad * Rad);
            Console.WriteLine($"Volume is :{Volume} and Sourface is:{sourface}");

            Console.ReadKey();

        }
    }
}
