using System;
using OOD_Uppgift.employee;

namespace OOD_Uppgift.menu
{
    public class UpdateMenu
    {
        public static void RunProgram()
        {
            Console.WriteLine("#-------------------------------------------------#");
            Console.WriteLine("#                Update Employee                  #");
            Console.WriteLine("#-------------------------------------------------#");
            
            Console.Write("Write your SocialID: ");
            string socialId = Util.ReadLine<string?>();

            Employee? employee = Program.registry.Get(socialId);
            if (employee == null)
            {
                Console.WriteLine($"#   Employee [{socialId}] Could not be found.");
                Program.ResetProgram();
                return;
            }

            Console.WriteLine("\n#--------------------------------------#");
            Console.WriteLine("#   Please choose your options below   #");
            Console.WriteLine("#--------------------------------------#");
            Console.WriteLine("# [1] - Update SocialID                #");
            Console.WriteLine("# [2] - Update Name                    #");
            Console.WriteLine("# [3] - Update WorkerType              #");
            Console.WriteLine("# [4] - Return                         #");
            Console.WriteLine("#--------------------------------------#");

            Console.Write("Option: ");
            var input = Util.ReadLine<int?>();

            Predicate<int> Invalidator = i => i is < 1 or > 4;

            while (input == null || Invalidator(input.Value))
            {
                Console.WriteLine("Invalid Input, Number should be between 1 and 4");
                Console.Write("Option: ");
                input = Util.ReadLine<int?>();
            }

            switch(input)
            {
                case 1:
                    //socail ID
                    Console.WriteLine("SocialId: ");
                    string newsocialID = Util.ReadLine<string?>();
                    Program.registry.Remove(socialId);
                    Program.registry.Add(newsocialID, employee);
                    break;
                case 2:
                    //Namn
                    Console.WriteLine("Name: ");
                    string newName = Util.ReadLine<string?>();
                    employee.name = newName;
                    Program.registry.Update(socialId, employee);
                    break;
                case 3:
                    //worker Type
                    var workertypes = WorkerTypeHandler.getTypes();
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

                    employee = Program.registry.Update(socialId, (emp) =>
                    {
                        emp.workertype = (WorkerType)emp_workertype_input;
                        return emp;
                    }
                    );
                    break;                
                case 4:
                    Console.WriteLine("Returning!");
                    break;
            }
            Program.ResetProgram();
        }
    }
}