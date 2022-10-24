using OOD_Uppgift.register;
using OOD_Uppgift.employee;
using System.Reflection.Metadata.Ecma335;

namespace OOD_Uppgift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing the registries!");

            BaseRegistry registry = new DictionaryRegistry();
            TestingResistry(registry);
            registry = new SortedListRegistry();
            TestingResistry(registry);
            registry = new LinkedRegistry();
            TestingResistry(registry);

        }
        public static void TestingResistry(BaseRegistry b)
        {
            Console.WriteLine("**Starting Test**");
            string[] keys = { "000", "111", "222", "333" };

            b.Add(keys[0], new Employee("Simon"));
            b.Add(keys[1], new Employee("Isak"));
            b.Add(keys[2], new Employee("Nils"));
            b.Add(keys[3], new Employee("Tim"));

            foreach( string employeekey in keys)
            {
                Employee? employee=b.Get(employeekey);
                if (employee!=null)
                { Console.WriteLine(employee.Name); }
            }
            Console.WriteLine("**Remove**");
            b.Remove(keys[2]);

            foreach (string employeekey in keys)
            {
                Employee? employee = b.Get(employeekey);
                if (employee != null)
                { Console.WriteLine(employee.Name); }
            }
            Console.WriteLine("**Update**");
            b.Update(keys[1], new Employee("Isak Ljunggren"));

            b.Update(keys[0],
                (x) => 
                { x.Name = "Simon Stålnäbb"; return x; }
                );

            foreach (string employeekey in keys)
            {
                Employee? employee = b.Get(employeekey);
                if (employee != null)
                { Console.WriteLine(employee.Name); }
            }

            Console.WriteLine("**Remove All**");
            b.RemoveAll();

            foreach (string employeekey in keys)
            {
                Employee? employee = b.Get(employeekey);
                if (employee != null)
                { Console.WriteLine(employee.Name); }
            }
        }
    }
}