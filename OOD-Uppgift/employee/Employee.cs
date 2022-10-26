using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Uppgift.employee
{
    internal class Employee
    {
        public string name;
        public WorkerType workertype;
        public Guid ID;
        public Dictionary<IEquipment,int> equipments = new ();

        public Employee(string employeeName, WorkerType wt) {
            name = employeeName;
            workertype = wt;
            Guid ID = Guid.NewGuid();
        }
        public void addEquipment(IEquipment equipment)
        {
            if (equipments.ContainsKey(equipment))
            {
                equipments[equipment] = +1;
            }
            else
            {
                equipments.Add(equipment, 1);
            }
        }
    }
}
