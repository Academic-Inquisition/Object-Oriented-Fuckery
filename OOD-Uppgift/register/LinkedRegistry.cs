using OOD_Uppgift.employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Uppgift.register
{
    internal class LinkedRegistry : BaseRegistry
    {
        private static DictionaryRegistry? registry;

        public LinkedRegistry()
        {
            // Stub
            // TODO: Implement LinkedList Version of Registry
        }

        public override bool Add(string socialId, Employee employee)
        {
            throw new NotImplementedException();
        }

        public override Employee Get(string socialId)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Employee employee)
        {
            throw new NotImplementedException();
        }

        public override bool Remove(string socialId)
        {
            throw new NotImplementedException();
        }

        public override void RemoveAll()
        {
            throw new NotImplementedException();
        }

        public override Employee Update(string socialId, Employee employee)
        {
            throw new NotImplementedException();
        }

        public override Employee Update(string socialId, Func<Employee, Employee> updateFunction)
        {
            throw new NotImplementedException();
        }

        public static BaseRegistry GetRegistry()
        {

            if (registry == null)
            {
                registry = new DictionaryRegistry();
                return registry;
            }
            return registry;
        }
    }
}
