using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Uppgift.employee
{
    public static interface IEquipment
    {
        string GetName();
        void DoWork();
    }



    public class Attire : IEquipment
    {
        public const string name;
        public const string workDesc;

        public Attire(string name, string workDesc)
        {
            this.name = name;
            this.workDesc = workDesc;
        }

        public string GetName()
        {
            return this.name;
        }

        public void DoWork()
        {
            Console.WriteLine(this.workDesc);
        }
    }

    public class Tool : IEquipment
    {
        public const string name;
        public const string workDesc;

        public Tool(string name, string workDesc)
        {
            this.name = name;
            this.workDesc = workDesc;
        }

        public string GetName()
        {
            return this.name;
        }

        public void DoWork()
        {
            Console.WriteLine(this.workDesc);
        }
    }

    

    internal class Employee 
    {
        public const Dictionary<IEquipment, int> equipments;

        public Employee()
        {
            this.equipments = new Dictionary<>();

            foreach(IEquipment equipment in Equipments)
            {

            }

        }
        
    }
}
