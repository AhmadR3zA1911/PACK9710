using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Copy_File
{
    class Program
    {
        static void Main(string[] args)
        {

            MainMenu(); // Load Menu :O
            var Option = Console.ReadLine(); // Get Option Number
            for (;;)
            {
                if (Option == "1")
                {
                    CopyFileToVirtualDrive();
                }

                else if (Option == "2")
                {
                    var DrivePath = DriverSelector();
                    GetDirectory(DrivePath);

                    Console.ReadKey();
                }

                else if (Option == "3")
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("\n\tAhmadR3zA - 1397/12/18 | Press Any Key To Exit ; )");
                    Console.ResetColor();

                    break;

                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n** Invalid Number , Press Any Key **");
                    Console.ReadKey();
                    Console.ResetColor();
                }
                MainMenu();
                Option = Console.ReadLine();

            }

            Console.ReadKey();
        }

        /// <summary>
        /// Main Menu For Choose Option
        /// </summary>
        static void MainMenu()
        {
            Console.Clear(); // Clear Screen
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(@" ---------------  ---------------  ---------------  ---------------");
            Console.WriteLine(@" -:::::::::::::-  -:::::::::::::-  -:::::::::::::-  -:::::::::::::-");
            Console.WriteLine(@"  ---------------  ---------------  ---------------  ---------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1.Copy Current Session");
            Console.WriteLine("____  ____  ____  ____ \n");
            Console.WriteLine("2.Select Source Folder");
            Console.WriteLine("____  ____  ____  ____ \n");
            Console.WriteLine("3.Exit : )");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(@" ---------------  ---------------  ---------------  ---------------");
            Console.WriteLine(@" -:::::::::::::-  -:::::::::::::-  -:::::::::::::-  -:::::::::::::-");
            Console.WriteLine(@"  ---------------  ---------------  ---------------  ---------------");
            Console.ResetColor();
            Console.Write("Enter Option Number:");



        }

        static string DriverSelector()
        {
            Console.Clear();
            Console.ResetColor();
            DriveInfo[] drives = DriveInfo.GetDrives();
            for (int i = 0; i < drives.Length; i++)
            {
                if (drives[i].IsReady)
                {
                    Console.WriteLine($"{i + 1}.{drives[i].Name}\t\t{(drives[i].IsReady ? drives[i].VolumeLabel : "Not Ready")}\t\t{drives[i].TotalFreeSpace / 1024 / 1024 / 1024}/{drives[i].TotalSize / 1024 / 1024 / 1024}\t\t{drives[i].DriveType}");
                }
            }
            Console.Write("Please Choose Drive Number:");

            return drives[int.Parse(Console.ReadLine()) - 1].Name.ToString();
        }

        /// <summary>
        /// Get List Of Directory and Files 
        /// </summary>
        /// <param name="_path"></param>
        static void GetDirectory(string _path = "c:\\")
        {
            Console.Clear();
            DirectoryInfo di = new DirectoryInfo(_path);
            DirectoryInfo[] subdir = di.GetDirectories();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("0.Previous Directory ../");

            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < subdir.Length; i++)
            {
                Console.WriteLine($"{i + 1}.{subdir[i].Name}");
            }
            FileInfo[] file = di.GetFiles();

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            for (int i = 0; i < file.Length; i++)
            {
                Console.WriteLine($"{i + subdir.Length + 1}.{file[i].Name}");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Please Choose Your Option: (Enter -1 for Select Current Directory):");
            var op = int.Parse(Console.ReadLine());

            if (op > 0 && op <= subdir.Length)
            {
                GetDirectory(subdir[op - 1].FullName);
            }
            else if (op > subdir.Length && op <= file.Length + subdir.Length)
            {
                Process.Start(file[op - subdir.Length - 1].FullName);
            }
            else if (op == 0)
            {
                if (di.Parent != null)
                {
                    GetDirectory(di.Parent.FullName);
                }
                else
                {
                    GetDirectory(DriverSelector());
                }
            }

            else if (op == -1)
            {
                using (StreamWriter sw = new StreamWriter("srcPath.txt"))
                {
                    sw.WriteLine(di.FullName);
                }
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Path Save Successfully to srcPath.txt\n({0})", di.FullName);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n** Invalid Number , Press Any Key **");
                Console.ReadKey();
                Console.ResetColor();
            }



        }


        static void CopyFileToVirtualDrive()
        {
            string srcPath = "";
            List<string> rmdrive = new List<string>();
            List<string> srcFile = new List<string>();

            using (StreamReader s = new StreamReader("srcPath.txt"))

            {
                srcPath = s.ReadToEnd();
            }
            if (srcPath !="")
            {
                DriveInfo [] rdrive = DriveInfo.GetDrives();
                foreach (DriveInfo item in rdrive)
                {
                    if(item.DriveType==DriveType.Removable && item.IsReady)
                    {
                        rmdrive.Add(item.Name);
                    }
                }
                DirectoryInfo di = new DirectoryInfo(srcPath);
                FileInfo[] file = di.GetFiles();
                foreach (FileInfo item in file)
                {
                    if (item.LastWriteTime.Date == DateTime.Now.Date)
                    {
                        srcFile.Add(item.Name);
                    }
                }

                foreach (string  filename in srcFile)
                {
                    foreach (string rd in rmdrive)
                    {
                        File.Copy(srcPath.Replace("\r\n","")+"\\"+filename, rd+filename ,true);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{filename} SuccessFully Copy to {rd}");
                    }

                }
                Console.ResetColor();
                Console.ReadKey();

            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n** Please Select Source Path **");
                Console.ReadKey();
                Console.ResetColor();
            }

        }

    }
}
