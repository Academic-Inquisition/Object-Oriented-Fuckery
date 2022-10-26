using OOD_Uppgift.register;
using System;

namespace OOD_Uppgift.menu
{
    public class RegistryMenu
    {
        private static readonly Predicate<int> Invalidator = i => i is < 1 or > 3;

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
            Console.WriteLine("#-------------------------------------------------#");
            Console.WriteLine("#   Change Registry Type                          #");
            Console.WriteLine("#-------------------------------------------------#");
            Console.WriteLine("#   Current Registry Type                         #");
            Console.WriteLine(structureString);
            Console.WriteLine("#-------------------------------------------------#");
            Console.WriteLine("#   [1] Dictionary                                #");
            Console.WriteLine("#   [2] Linked List                               #");
            Console.WriteLine("#   [3] Return                                    #");

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
                    if (Program.dataStructure != "Dictionary")
                    {
                        Program.registry = new DictionaryRegistry();
                        Program.dataStructure = "Dictionary";
                    }
                    break;
                case 2:
                    if (Program.dataStructure != "Linked List")
                    {
                        Program.registry = new LinkedRegistry();
                        Program.dataStructure = "Linked List";
                    }
                    break;
                default:

                    break;
            }

            Program.ActiveProgram = -1;
        }

        //private void MigrateNOTDatabase(string input)
        //{

        //}
    }
}