﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace OOD_Uppgift.menu
{
    public class MainMenu
    {
        private static readonly Predicate<int> Invalidator = i => i is < 1 or > 5;
        public static string? dataStructure, structureString;

        public static void RunProgram()
        {
            // Lägg till kontroll för vilken data structure som används
            // dataStructure = "Dictionary" || datastructure = "Linked List"

            switch(dataStructure)
            {
                case "Dictionary":
                    structureString = "#              Dictionary              #";
                    break;
                case "Linked List":
                    structureString = "#             Linked List              #";
                    break;
                case null:
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
            Console.WriteLine("# [4] - Change data structure          #");
            Console.WriteLine("# [5] - Exit                           #");
            Console.WriteLine("#--------------------------------------#");
            
            Console.Write("Option: ");
            var input = Util.ReadLine<int?>();

            while (input == null || Invalidator(input.Value))
            {
                Console.WriteLine("Invalid Input, Number should be between 1 and 5");
                Console.Write("Option: ");
                input = Util.ReadLine<int>();
            }
            
            Program.ActiveProgram = input.Value;
        }
    }
}