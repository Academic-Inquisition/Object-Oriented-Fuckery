using System;
using Microsoft.Win32;
using System.Collections;
using OOD_Uppgift.register;
using System.Collections.Generic;

namespace OOD_Uppgift.menu
{
    public class MainMenu
    {
        private static readonly Predicate<int> Invalidator = i => i is < 1 or > 7;

        public static void RunProgram()
        {
            Console.Clear();
            Console.WriteLine("#--------------------------------------#");
            Console.WriteLine("# Register loaded with data structure: #");
            if(Program.registry.GetType() == typeof(DictionaryRegistry))
            {
                Console.WriteLine("#              Dictionary              #");
            }
            else if (Program.registry.GetType() == typeof(LinkedRegistry))
            {
                Console.WriteLine("#             Linked List              #");
            }
            Console.WriteLine("#--------------------------------------#");
            Console.WriteLine("#   Please choose your options below   #");
            Console.WriteLine("#--------------------------------------#");
            Console.WriteLine("# [1] - Add an employee                #");
            Console.WriteLine("# [2] - Update an employee             #");
            Console.WriteLine("# [3] - Remove an employee             #");
            Console.WriteLine("# [4] - Get an employee                #");
            Console.WriteLine("# [5] - Change data structure          #");
            Console.WriteLine("# [6] - Run performance test           #");
            Console.WriteLine("# [7] - Exit                           #");
            Console.WriteLine("#--------------------------------------#");
            
            Console.Write("Option: ");
            var input = Util.ReadLine<int?>();

            while (input == null || Invalidator(input.Value))
            {
                Console.WriteLine("Invalid Input, Number should be between 1 and 7");
                Console.Write("Option: ");
                input = Util.ReadLine<int?>();
            }
            
            Program.ActiveProgram = input.Value;
        }
    }
}