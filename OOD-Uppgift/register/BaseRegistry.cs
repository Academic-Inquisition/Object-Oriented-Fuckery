using OOD_Uppgift.employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Uppgift.register
{
    internal abstract class BaseRegistry {

        public abstract bool Add(string socialId, Employee employee);

        public abstract Employee? Get(string socialId);

        public abstract Employee? Update(string socialId, Employee employee);
        public abstract Employee? Update(string socialId, Func<Employee, Employee> updateFunction);

        public abstract bool Remove(string socialId);
        public abstract void RemoveAll();

    }
}
