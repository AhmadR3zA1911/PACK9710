namespace SimpleLibrary
{
    public class Class1
    {
        using System;

    namespace ASCIIDesign
    {
        class Program
        {
            static void Main()
            {
                Console.Title = "ASCII Art";
                string title = @"
 ____                                     ______    __    ___             
/\  _`\                                  /\__  _\__/\ \__/\_ \            
\ \ \L\_\ __      ___     ___   __  __   \/_/\ \/\_\ \ ,_\//\ \      __   
 \ \  _\/'__`\  /' _ `\  /'___\/\ \/\ \     \ \ \/\ \ \ \/ \ \ \   /'__`\ 
  \ \ \/\ \L\.\_/\ \/\ \/\ \__/\ \ \_\ \     \ \ \ \ \ \ \_ \_\ \_/\  __/ 
   \ \_\ \__/.\_\ \_\ \_\ \____\\/`____ \     \ \_\ \_\ \__\/\____\ \____\
    \/_/\/__/\/_/\/_/\/_/\/____/ `/___/> \     \/_/\/_/\/__/\/____/\/____/
                                    /\___/                                
                                    \/__/                                 
                                                                 ";

                Console.WriteLine(title);
                Console.Read();
            }
        }
    }
    }
}