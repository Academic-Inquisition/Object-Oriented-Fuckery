using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace OOD_Uppgift.employee
{
    internal class Employee
    {
        //Guid not optimal
        public string name;
        public WorkerType workertype;
        public Guid ID;
        public Dictionary<IEquipment,int> Equipments = new ();

        public Employee(string employeeName, WorkerType wt) {
            name = employeeName;
            workertype = wt;
            ID = Guid.NewGuid();
        }
        
        public void AddEquipment(IEquipment equipment)
        {
            if (Equipments.ContainsKey(equipment))
            {
                Equipments[equipment] = +1;
            }
            else
            {
                Equipments.Add(equipment, 1);
            }
        }
    }
}
