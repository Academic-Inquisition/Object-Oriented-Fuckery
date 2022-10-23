using System.Linq;
using OOD_Uppgift.employee;

namespace OOD_Uppgift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Equipments.init();
            Employee employee = new Employee("Isak", WorkerType.Ant);
            var hits = Equipments.items.Where(i => i.getName() == "Hammer").ToList();
            if (hits.Count() > 0)
                //Console.WriteLine(hits[0].getName());
                employee.addEquipment(hits[0]);
            Console.WriteLine($"{employee.name}, {employee.workertype}, {employee.equipments[0].getName()}");

            //employee.addEquipment();
            //WorkerTypeHandler wth = new WorkerTypeHandler();
            //var result = wth.getTypes();
            //foreach (KeyValuePair<int, string> kvp in result)
            //Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
        }
    }
}