using System;
using OOD_Uppgift.employee;
using OOD_Uppgift.register;

namespace OOD_Uppgift.menu
{
    public class GetMenu
    {
        public static void RunProgram()
        {
            Console.WriteLine("#-------------------------------------------------#");
            Console.WriteLine("#                 Get Employee                    #");
            Console.WriteLine("#-------------------------------------------------#");

            Console.Write("Enter your SocialID: ");
            string socialId = Util.ReadLine<string?>();
            
            Employee? employee = Program.registry.Get(socialId);

            if(employee != null)
            {
                var workertypes = WorkerTypeHandler.getTypes();
                Console.Clear();
                Console.WriteLine($"SocialID: {socialId}");
                Console.WriteLine($"Name: {employee.name}");
                Console.WriteLine($"WokerType: {workertypes[(int)employee.workertype]}");
                Console.WriteLine($"GUID: {employee.ID.ToString()}");
            }

            Console.WriteLine("Press any key to return to main menu...");
            Console.ReadKey();
            Program.ResetProgram();
        }
    }
}