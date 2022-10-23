using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Uppgift.employee
{
    public class Attire : IEquipment
    {
        public string name;
        public string workDesc;

  public Attire(String attireName, String desc)
        {
            name = attireName;
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
