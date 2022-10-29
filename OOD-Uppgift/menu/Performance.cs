using System;
using OOD_Uppgift.employee;
using OOD_Uppgift.register;

namespace OOD_Uppgift.menu
{
    public class Performance
    {
        internal static int span = 10000;
        internal static int step = span/5;
        internal static void AddTest(BaseRegistry testRegistry)
        {
            for(int i = 1; i <= span; i++)
            {
                testRegistry.Add(i.ToString(), new Employee(i.ToString(), WorkerType.Ant));
                if (i % step == 0)
                {
                    Console.WriteLine($"Progress: {i}/{span}");
                }
            }
        }

        internal static void UpdateTest(BaseRegistry testRegistry)
        {
            for(int i = 1; i <= span; i++)
            {
                testRegistry.Update(i.ToString(), new Employee((i + 1).ToString(), WorkerType.Bumblebee));
                if (i % step == 0)
                {
                    Console.WriteLine($"Progress: {i}/{span}");
                }
            }
        }

        internal static void ReadTest(BaseRegistry testRegistry)
        {
            for(int i = 1; i <= span; i++)
            {
                testRegistry.Get(i.ToString());
                if (i % step == 0)
                {
                    Console.WriteLine($"Progress: {i}/{span}");
                }
            }
        }

        internal static void RemoveTest(BaseRegistry testRegistry)
        {
            for(int i = 1; i <= span; i++)
            {
                testRegistry.Remove(i.ToString());
                if (i % step == 0)
                {
                    Console.WriteLine($"Progress: {i}/{span}");
                }
            }
        }
    }
}