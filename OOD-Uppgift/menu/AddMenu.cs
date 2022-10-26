using OOD_Uppgift.employee;
using System;

namespace OOD_Uppgift.menu
{
    public class AddMenu
    {
        //private static readonly Predicate<int> Invalidator = i => i is < 1 or > 4;

        public static void RunProgram()
        {
            Console.WriteLine("#-------------------------------------------------#");
            Console.WriteLine("#                                                 #");
            Console.WriteLine("#                                                 #");
            Console.WriteLine("#-------------------------------------------------#");
            Console.WriteLine("#   Add Employee                                  #");
            Console.WriteLine("#-------------------------------------------------#");
            Console.WriteLine("#   Skriv in ditt personummer                     #");
            Console.Write("personnummer: ");
            string socialId = Util.ReadLine<string?>();
            Console.WriteLine("#   Skriv in ditt namn                     #");
            Console.Write("namn: ");
            string name = Util.ReadLine<string?>();

            var workertypes = WorkerTypeHandler.getTypes();

            Console.WriteLine("#   Välj vilken workertype du är                #");
            foreach (var workertype in workertypes)
            {
                Console.WriteLine($"[{workertype.Key}] {workertype.Value}");
            }

            Console.Write("WorkerType: ");
            var emp_workertype_input = Util.ReadLine<int?>();

            while (emp_workertype_input == null || !workertypes.ContainsKey((int)emp_workertype_input))
            {
                foreach (var workertype in workertypes)
                {
                    Console.WriteLine($"[{workertype.Key}] {workertype.Value}");
                }
                Console.WriteLine("Invalid Input, Workertype ");
                Console.Write("WorkerType: ");
                emp_workertype_input = Util.ReadLine<int?>();
            }

            Program.registry.Add(socialId,new Employee(name,(WorkerType)emp_workertype_input));
            Program.ActiveProgram = -1;
        }
    }
}
