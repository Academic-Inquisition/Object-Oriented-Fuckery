using System;
using System.Diagnostics; 
using OOD_Uppgift.register;

namespace OOD_Uppgift.menu
{
    public class PerfTestMenu
    {
        static bool bothTested;
        public static string? testStructure;
        static Stopwatch stopwatch = new();
        static BaseRegistry? testRegistry;
        private static readonly Predicate<int> Invalidator = i => i is < 1 or > 3;

        public static void RunProgram()
        {   
            bothTested = false;

            Console.WriteLine("#--------------------------------------#");
            Console.WriteLine("#  Choose which data structure to test #");
            Console.WriteLine("#--------------------------------------#");
            Console.WriteLine("# [1] - Dictionary                     #");
            Console.WriteLine("# [2] - Linked List                    #");
            Console.WriteLine("# [3] - Exit                           #");
            Console.WriteLine("#--------------------------------------#");
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
                    testRegistry = new DictionaryRegistry();
                    testStructure = "Dictionary";
                    Console.Clear();
                    PerfTest(testRegistry);
                    break;
                case 2:
                    testRegistry = new LinkedRegistry();
                    testStructure = "Linked List";
                    Console.Clear();
                    PerfTest(testRegistry);
                    break;
                default:
                    break;
            }
            
            Program.ResetProgram();
        }

        internal static void PerfTest(BaseRegistry? registry)
        {
            Console.WriteLine($"Using data structure '{testStructure}'");
            Console.WriteLine($"\nRunning test #1: 'Add employees'");
            stopwatch.Start();
            Performance.AddTest(registry);
            stopwatch.Stop();
            Console.WriteLine($"Test completed! Employees added: 50000, Time elapsed: {stopwatch.Elapsed}");

            stopwatch = new();
            Console.WriteLine("\nRunning test #2: 'Update employees'");
            stopwatch.Start();
            Performance.UpdateTest(registry);
            stopwatch.Stop();
            Console.WriteLine($"Test completed! Employees updated: 50000, Time elapsed: {stopwatch.Elapsed}");

            stopwatch = new();
            Console.WriteLine("\nRunning test #3: 'Read employee data'");
            stopwatch.Start();
            Performance.ReadTest(registry);
            stopwatch.Stop();
            Console.WriteLine($"Test completed! Employee entries read: 50000, Time elapsed: {stopwatch.Elapsed}");

            stopwatch = new();
            Console.WriteLine("\nRunning test #4: 'Remove employees'");
            stopwatch.Start();
            Performance.RemoveTest(registry);
            stopwatch.Stop();
            Console.WriteLine($"Test completed! Employees removed: 50000, Time elapsed: {stopwatch.Elapsed}\n");

            if (bothTested == false)
            {
                Console.WriteLine($"You have tested the following data structure: '{testStructure}'");
                Console.WriteLine("Do you want to test the other structure as well? (Y/N)");
                var input = Util.ReadLine<string?>();

                Console.WriteLine();

                if (input == "Y" || input == "y")
                {   
                    bothTested = true;

                    if (testStructure == "Dictionary")
                    {
                        testRegistry = new LinkedRegistry();
                        testStructure = "Linked List";
                        PerfTest(testRegistry);
                    }
                    else 
                    {
                        testRegistry = new DictionaryRegistry();
                        testStructure = "Dictionary";
                        PerfTest(testRegistry);
                    }
                }
            }
            
            Console.Write("Press any key to return to main menu...");
            Console.ReadKey();
        }
    }
}