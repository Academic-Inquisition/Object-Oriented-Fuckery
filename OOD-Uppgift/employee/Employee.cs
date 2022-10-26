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
        public List<IEquipment> equipments = new List<IEquipment>();

        public Employee(string employeeName, WorkerType wt) {
            name = employeeName;
            workertype = wt;
            Guid ID = Guid.NewGuid();
        }
        public void addEquipment(IEquipment equipment)
        {
            equipments.Add(equipment);
        }
    }
}
