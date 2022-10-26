using OOD_Uppgift.employee;
using OOD_Uppgift.register;
using System;

namespace OOD_Uppgift.menu
{
    public class GetMenu
    {
        public static void RunProgram()
        {
            Console.WriteLine("#-------------------------------------------------#");
            Console.WriteLine("#   Get Employee                                  #");
            Console.WriteLine("#-------------------------------------------------#");
            Console.WriteLine("#   Skriv in personnummret                     #");
            Console.Write("personnummer: ");
            string socialId = Util.ReadLine<string?>();
            Employee? employee = Program.registry.Get(socialId);
            if(employee == null)
            {
                Console.WriteLine($"#   Employee [{socialId}] Could not be found.");
            }
            else
            {
                var workertypes = WorkerTypeHandler.getTypes();
                Console.WriteLine($"Personnummer: {socialId}");
                Console.WriteLine($"namn: {employee.name}");
                Console.WriteLine($"WokerType: {workertypes[(int)employee.workertype]}");
                Console.WriteLine($"GUID: {employee.ID}");
            }
            Program.ActiveProgram = -1;
        }
    }
}