using System;
using OOD_Uppgift.register;

namespace OOD_Uppgift.menu
{
    public class RegistryMenu
    {
        private static readonly Predicate<int> Invalidator = i => i is < 1 or > 3;

        public static void RunProgram()
        {

            Console.WriteLine("#-------------------------------------------------#");
            Console.WriteLine("#   Change Registry Type                          #");
            Console.WriteLine("#-------------------------------------------------#");
            Console.WriteLine("#   Current Registry Type                         #");
            if (Program.registry.GetType() == typeof(DictionaryRegistry))
            {
                Console.WriteLine("#              Dictionary              #");
            }
            else if (Program.registry.GetType() == typeof(LinkedRegistry))
            {
                Console.WriteLine("#             Linked List              #");
            }
            Console.WriteLine("#-------------------------------------------------#");
            Console.WriteLine("#   [1] Dictionary                                #");
            Console.WriteLine("#   [2] Linked List                               #");
            Console.WriteLine("#   [3] Exit                                      #");
            Console.WriteLine("#-------------------------------------------------#");

            Console.Write("Option: ");
            var input = Util.ReadLine<int?>();

            while (input == null || Invalidator(input.Value))
            {
                Console.WriteLine("Invalid Input, Number should be between 1 and 3");
                Console.Write("Option: ");
                input = Util.ReadLine<int>();
            }

            switch(input)
            {
                case 1:
                    if (Program.registry.GetType() != typeof(DictionaryRegistry))
                    {
                        Program.registry = new DictionaryRegistry();
                    }
                    break;
                case 2:
                    if (Program.registry.GetType() != typeof(LinkedRegistry))
                    {
                        Program.registry = new LinkedRegistry();
                    }
                    break;
            }

            Program.ResetProgram();
        }
    }
}