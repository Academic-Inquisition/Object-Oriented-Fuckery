using System;
using System.Collections;
using System.Collections.Generic;

namespace OOD_Uppgift.menu
{
    public class MainMenu
    {
        private static readonly Predicate<int> Invalidator = i => i is < 1 or > 6;


        public static void RunProgram()
        {
            string structureString;
            
            switch (Program.dataStructure)
            {
                case "Dictionary":
                    structureString = "#              Dictionary              #";
                    break;
                case "Linked List":
                    structureString = "#             Linked List              #";
                    break;
                default:
                    structureString = "#     No data structure initialized    #";
                    break;
            }

            Console.WriteLine("#--------------------------------------#");
            Console.WriteLine("# Register loaded with data structure: #");
            Console.WriteLine(structureString);
            Console.WriteLine("#--------------------------------------#");
            Console.WriteLine("#   Please choose your options below   #");
            Console.WriteLine("#--------------------------------------#");
            Console.WriteLine("# [1] - Add an employee                #");
            Console.WriteLine("# [2] - Update an employee             #");
            Console.WriteLine("# [3] - Remove an employee             #");
            Console.WriteLine("# [4] - Get an employee                #");
            Console.WriteLine("# [5] - Change data structure          #");
            Console.WriteLine("# [6] - Exit                           #");
            Console.WriteLine("#--------------------------------------#");
            
            Console.Write("Option: ");
            var input = Util.ReadLine<int?>();

            while (input == null || Invalidator(input.Value))
            {
                Console.WriteLine("Invalid Input, Number should be between 1 and 6");
                Console.Write("Option: ");
                input = Util.ReadLine<int>();
            }
            
            Program.ActiveProgram = input.Value;
        }
    }
}