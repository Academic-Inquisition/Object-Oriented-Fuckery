using OOD_Uppgift.employee;
using System;

namespace OOD_Uppgift.menu
{
    public class RemoveMenu
    {
        public static void RunProgram()
        {
            Console.WriteLine("#-------------------------------------------------#");
            Console.WriteLine("#   Remove Employee                               #");
            Console.WriteLine("#-------------------------------------------------#");
            Console.WriteLine("#   Type your SocialID                            #");
            Console.Write("SocialID: ");
            string socialId = Util.ReadLine<string?>();

            if (Program.registry.Remove(socialId))
            {
                Console.WriteLine($"Employee {socialId} was removed.");
                
            }
            else
            {
                Console.WriteLine($"Employee {socialId} Could not be found.");
            }

            Program.ResetProgram();
        }
    }
}