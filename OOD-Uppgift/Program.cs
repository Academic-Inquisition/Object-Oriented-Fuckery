using System;
using OOD_Uppgift.menu;

namespace OOD_Uppgift
{
    public static class Program
    {
        public static int ActiveProgram = -1;

        public static void Main(string[] args)
        {
            while (!Environment.HasShutdownStarted)
            {
                while (ActiveProgram == -1)
                {
                    MainMenu.RunProgram();
                    break;
                }

                Console.Clear();
                switch (ActiveProgram)
                {
                    case 1:
                        AddMenu.RunProgram();
                        break;
                    case 2:
                        UpdateMenu.RunProgram();
                        break;
                    case 3:
                        RemoveMenu.RunProgram();
                        break;
                    case 4:
                        Console.WriteLine("Press any key to close this window");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public static void ResetProgram()
        {
            ActiveProgram = -1;
        }
    }
}