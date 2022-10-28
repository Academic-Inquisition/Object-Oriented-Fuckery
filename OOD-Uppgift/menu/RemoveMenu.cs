using System;
using OOD_Uppgift.employee;

namespace OOD_Uppgift.menu
{
    public class RemoveMenu
    {
        public static void RunProgram()
        {
            Console.WriteLine("#-------------------------------------------------#");
            Console.WriteLine("#               Remove Employee                   #");
            Console.WriteLine("#-------------------------------------------------#");
            
            Console.Write("Write your SocialID: ");
            string socialId = Util.ReadLine<string?>();

            if (Program.registry.Remove(socialId))
            {
                Console.WriteLine($"Employee {socialId} was removed.");
            }
            else
            {
                Console.WriteLine($"Employee {socialId} could not be found.");
            }

            Console.WriteLine("Press any key to return to main menu...");
            Console.ReadKey();
            Program.ResetProgram();
        }
    }
}