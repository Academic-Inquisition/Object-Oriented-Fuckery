using System;
using System.Collections;
using System.Collections.Generic;

namespace OOD_Uppgift.menu
{
    public class MainMenu
    {
        private static readonly Predicate<int> Invalidator = i => i is < 1 or > 4;

        public static void RunProgram()
        {
            Console.WriteLine("#--------------------------------------#");
            Console.WriteLine("#                                      #");
            Console.WriteLine("#                                      #");
            Console.WriteLine("#--------------------------------------#");
            Console.WriteLine("#   Please choose your options below   #");
            Console.WriteLine("#--------------------------------------#");
            Console.WriteLine("# [1] - Add an employee                #");
            Console.WriteLine("# [2] - Update an employee             #");
            Console.WriteLine("# [3] - Remove an employee             #");
            Console.WriteLine("# [4] - Exit                           #");
            Console.WriteLine("#--------------------------------------#");
            
            Console.Write("Option: ");
            var input = Util.ReadLine<int?>();

            while (input == null || Invalidator(input.Value))
            {
                Console.WriteLine("Invalid Input, Number should be between 1 and 4");
                Console.Write("Option: ");
                input = Util.ReadLine<int>();
            }
            
            Program.ActiveProgram = input.Value;
        }
    }
}