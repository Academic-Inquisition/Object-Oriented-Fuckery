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
            Console.WriteLine("#   Add Employee                                  #");
            Console.WriteLine("#-------------------------------------------------#");
            Console.WriteLine("#   Type your SocialID                            #");
            Console.Write("SocialID: ");
            string socialId = Util.ReadLine<string?>();
            Console.WriteLine("#   Type in your Name                             #");
            Console.Write("Name: ");
            string name = Util.ReadLine<string?>();

            var workertypes = WorkerTypeHandler.getTypes();

            Console.WriteLine("#   Choose your workertype                        #");
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
            Program.ResetProgram();
        }
    }
}
