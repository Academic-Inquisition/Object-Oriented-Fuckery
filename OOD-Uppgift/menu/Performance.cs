using System;
using OOD_Uppgift.employee;
using OOD_Uppgift.register;

namespace OOD_Uppgift.menu
{
    public class Performance
    {
        internal static void AddTest(BaseRegistry testRegistry)
        {
            for(int i = 1; i <= 50000; i++)
            {
                testRegistry.Add(i.ToString(), new Employee(i.ToString(), WorkerType.Ant));

                if (i % 10000 == 0)
                {
                    Console.WriteLine($"Progress: {i}/50000");
                }
            }
        }

        internal static void UpdateTest(BaseRegistry testRegistry)
        {
            for(int i = 1; i <= 50000; i++)
            {
                testRegistry.Update(i.ToString(), new Employee((i + 1).ToString(), WorkerType.Bumblebee));

                if (i % 10000 == 0)
                {
                    Console.WriteLine($"Progress: {i}/50000");
                }
            }
        }

        internal static void ReadTest(BaseRegistry testRegistry)
        {
            for(int i = 1; i <= 50000; i++)
            {
                testRegistry.Get(i.ToString());

                if (i % 10000 == 0)
                {
                    Console.WriteLine($"Progress: {i}/50000");
                }
            }
        }

        internal static void RemoveTest(BaseRegistry testRegistry)
        {
            for(int i = 1; i <= 50000; i++)
            {
                testRegistry.Remove(i.ToString());

                if (i % 10000 == 0)
                {
                    Console.WriteLine($"Progress: {i}/50000");
                }
            }
        }
    }
}