using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Uppgift.employee
{
    public class Tool : IEquipment
    {
        private string name;
        private string workDesc;

        public Tool(String toolName, String desc)
        {
            name = toolName;
            workDesc = desc;
        }

        public string getName()
        {
            return name;
        }

        public void doWork()
        {
            Console.WriteLine(workDesc);
            return; //STUB
        }
    }
}
