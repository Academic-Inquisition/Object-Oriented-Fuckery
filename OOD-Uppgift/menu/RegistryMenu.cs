using OOD_Uppgift.register;
using System;

namespace OOD_Uppgift.menu
{
    public class RegistryMenu
    {
        private static readonly Predicate<int> Invalidator = i => i is < 1 or > 3;

        public static void RunProgram()
        {

            Console.WriteLine("#-------------------------------------------------#");
            Console.WriteLine("#             Change Registry Type                #");
            Console.WriteLine("#-------------------------------------------------#");
            Console.WriteLine("#            Current Registry Type:               #");
            
            if (Program.registry is DictionaryRegistry)
            {
                Console.WriteLine("#                  Dictionary                     #");
            }
            else if (Program.registry is LinkedRegistry)
            {
                Console.WriteLine("#                  Linked List                    #");
            }
            Console.WriteLine("#-------------------------------------------------#");
            Console.WriteLine("#   [1] Dictionary                                #");
            Console.WriteLine("#   [2] Linked List                               #");
            Console.WriteLine("#   [3] Return                                    #");
            Console.WriteLine("#-------------------------------------------------#");

            Console.Write("Option: ");
            var input = Util.ReadLine<int?>();

            while (input == null || Invalidator(input.Value))
            {
                Console.WriteLine("Invalid Input, Number should be between 1 and 3");
                Console.Write("Option: ");
                input = Util.ReadLine<int?>();
            }

            switch(input)
            {
                case 1:
                    if (Program.registry is not DictionaryRegistry)
                    {
                        Program.registry = DictionaryRegistry.GetRegistry();
                    }
                    break;
                case 2:
                    if (Program.registry is not LinkedRegistry)
                    {
                        Program.registry = LinkedRegistry.GetRegistry();
                    }
                    break;
            }

            Program.ResetProgram();
        }
    }
}